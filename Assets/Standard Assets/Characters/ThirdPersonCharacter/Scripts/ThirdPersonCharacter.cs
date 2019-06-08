using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    // sorry for all the hacks to do edge climbing .... Benno.


    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    public class ThirdPersonCharacter : MonoBehaviour
    {
        [SerializeField] float m_MovingTurnSpeed = 360;
        [SerializeField] float m_StationaryTurnSpeed = 180;
        [SerializeField] float m_JumpPower = 12f;
        [Range(1f, 4f)] [SerializeField] float m_GravityMultiplier = 2f;
        [SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
        [SerializeField] float m_MoveSpeedMultiplier = 1f;
        [SerializeField] float m_AnimSpeedMultiplier = 1f;
        [SerializeField] float m_GroundCheckDistance = 0.5f;

        [Header("Edge Detection")]
        [SerializeField] bool showEdgeBox = true;
        [SerializeField] Vector3 m_EdgeBoxCenter = new Vector3(0, 1, 1);
        [SerializeField] Vector3 m_EdgeBoxDImensions = new Vector3(1, 2, 0.5f);
        [SerializeField] LayerMask m_EdgeLayerMask;
        [SerializeField] Vector3 m_EdgeGrabOffset;
        [SerializeField] float m_EdgeWallJumpForce = 3;
        [SerializeField] float m_EdgeGrabCooldown = 0.5f; //if edge was grabbed, dont immediately grab on again when released;

        Rigidbody m_Rigidbody;
        Animator m_Animator;
        bool m_IsGrounded;
        float m_OrigGroundCheckDistance;
        const float k_Half = 0.5f;
        float m_TurnAmount;
        float m_ForwardAmount;
        Vector3 m_GroundNormal;
        float m_CapsuleHeight;
        Vector3 m_CapsuleCenter;
        CapsuleCollider m_Capsule;
        bool m_Crouching;
        public AudioSource aS;
        public AudioClip shootclip;
        public GameObject shootpat;
        public GameObject Shootingpoint;
        public Transform target;
        //EdgeGrab
        bool m_EdgeGrabbed;
        bool m_EdgePullup;
        float m_LastEdgeGrabbed = 0;
        public GameObject otherObject;
        public Animator otherAnimator;


        float speed;

        void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();
            m_CapsuleHeight = m_Capsule.height;
            m_CapsuleCenter = m_Capsule.center;

            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            m_OrigGroundCheckDistance = m_GroundCheckDistance;
        }


        public void Move(Vector3 move, bool crouch, bool jump)
        {
            // extract vertical input;
            float verticalInput = move.y;
            move.y = 0;

            // convert the world relative moveInput vector into a local-relative
            // turn amount and forward amount required to head in the desired
            // direction.
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            CheckGroundStatus();
            move = Vector3.ProjectOnPlane(move, m_GroundNormal);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            m_ForwardAmount = move.z;

            ApplyExtraTurnRotation();

            // control and velocity handling is different when grounded and airborne:
            if (m_IsGrounded)
            {
                HandleGroundedMovement(crouch, jump);
            }
            else
            {
                HandleEdgeGrab(jump, move, verticalInput);
                HandleAirborneMovement();
            }

            //ScaleCapsuleForCrouching(crouch);
            //PreventStandingInLowHeadroom();

            // send input and other state parameters to the animator
            UpdateAnimator(move);
        }


        private void Awake()
        {
            otherAnimator = otherObject.GetComponent<Animator>();
        }

        void ScaleCapsuleForCrouching(bool crouch)
        {
            if (m_IsGrounded && crouch)
            {
                if (m_Crouching) return;
                m_Capsule.height = m_Capsule.height / 2f;
                m_Capsule.center = m_Capsule.center / 2f;
                m_Crouching = true;
            }
            else
            {
                Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
                float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
                if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
                {
                    m_Crouching = true;
                    return;
                }
                m_Capsule.height = m_CapsuleHeight;
                m_Capsule.center = m_CapsuleCenter;
                m_Crouching = false;
            }
        }

        void PreventStandingInLowHeadroom()
        {
            // prevent standing up in crouch-only zones
            if (!m_Crouching)
            {
                Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
                float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
                if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
                {
                    m_Crouching = true;
                }
            }
        }

        void UpdateAnimator(Vector3 move)
        {
            // update the animator parameters
            m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
            m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
            m_Animator.SetBool("Crouch", m_Crouching);
            m_Animator.SetBool("OnGround", m_IsGrounded);
            m_Animator.SetBool("EdgeGrab", m_EdgeGrabbed);
            m_Animator.SetBool("EdgePullup", m_EdgePullup);
            if (!m_IsGrounded)
            {
                m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
            }

            // calculate which leg is behind, so as to leave that leg trailing in the jump animation
            // (This code is reliant on the specific run cycle offset in our animations,
            // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
            float runCycle =
                Mathf.Repeat(
                    m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
            float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
            if (m_IsGrounded)
            {
                m_Animator.SetFloat("JumpLeg", jumpLeg);
            }

            // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
            // which affects the movement speed because of the root motion.
            if (m_IsGrounded && move.magnitude > 0)
            {
                m_Animator.speed = m_AnimSpeedMultiplier;
            }
            else
            {
                // don't use that while airborne
                m_Animator.speed = 1;
            }





            if (Input.GetKeyDown("joystick button 4"))
            {
                m_Animator.SetBool("Aiming", true);
            }
            if (Input.GetKeyUp("joystick button 4"))
            {
                m_Animator.SetBool("Aiming", false);
            }

            if (Input.GetKeyDown("joystick button 5"))
            {
                m_Animator.SetTrigger("Shoot");

                GameObject shootpatinstant;
                shootpatinstant = Instantiate(shootpat, Shootingpoint.transform.position, Shootingpoint.transform.rotation) as GameObject;
                aS.PlayOneShot(shootclip);


                //Do anything else related to shooting.
            }

        }
        
        public void KillMonitor()
        {

            otherAnimator.SetBool("Deactivate", true);


        }
        

        void HandleAirborneMovement()
        {
            // apply extra gravity from multiplier:
            Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
            m_Rigidbody.AddForce(extraGravityForce);

            m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;

        }

        void HandleEdgeGrab(bool jump, Vector3 move, float verticalInput)
        {
            if (m_EdgePullup)
            {
                return;
            }

            if (m_EdgeGrabbed)
            {
                m_LastEdgeGrabbed = Time.time;
                if (jump) // jump away from edge
                {
                    m_Rigidbody.velocity += -transform.forward * m_EdgeWallJumpForce;
                    Jump();
                    m_EdgeGrabbed = false;
                    m_Animator.SetTrigger("EdgeLetGo");
                    return;
                }
                if (verticalInput > 0) // pull up from edge
                {
                    m_EdgeGrabbed = false;
                    m_EdgePullup = true;
                    m_Capsule.height = m_Capsule.height / 2f;
                    Invoke("EdgePullupComplete", 0.6f);
                    return;
                }
                if (verticalInput < 0) // let go from edge
                {
                    m_EdgeGrabbed = false;
                    m_Animator.SetTrigger("EdgeLetGo");
                    return;
                }
            }

            Collider[] edges = (Physics.OverlapBox(transform.position + transform.rotation * m_EdgeBoxCenter, m_EdgeBoxDImensions / 2f, transform.rotation, m_EdgeLayerMask));

            if (edges.Length != 0)
            {
                if (!m_EdgeGrabbed && Time.time > m_LastEdgeGrabbed + m_EdgeGrabCooldown && m_Rigidbody.velocity.y <= 0)
                {
                    m_EdgeGrabbed = true;
                }

                if (m_EdgeGrabbed)
                {
                    transform.position = Vector3.Lerp(transform.position, edges[0].transform.position + edges[0].transform.rotation * m_EdgeGrabOffset, Time.deltaTime * 5);
                    transform.rotation = Quaternion.Slerp(transform.rotation, edges[0].transform.rotation, Time.deltaTime * 50);
                    m_Rigidbody.velocity = Vector3.zero;
                }
            }
            else
            {
                m_EdgeGrabbed = false;
            }
        }

        void EdgePullupComplete()
        {
            m_Capsule.height = m_Capsule.height * 2f;
            m_EdgePullup = false;
        }

        void HandleGroundedMovement(bool crouch, bool jump)
        {
            // check whether conditions are right to allow a jump:
            if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                Jump();
            }
        }

        void Jump()
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
            m_IsGrounded = false;
            m_Animator.applyRootMotion = false;
            m_GroundCheckDistance = 0.1f;
        }

        void ApplyExtraTurnRotation()
        {
            if (m_EdgePullup || m_EdgeGrabbed)
            {
                return;
            }

            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        }


        public void OnAnimatorMove()
        {
            // we implement this function to override the default root motion.
            // this allows us to modify the positional speed before it's applied.
            if (m_IsGrounded && Time.deltaTime > 0)
            {
                Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

                if (!m_EdgePullup)
                {
                    // we preserve the existing y part of the current velocity.
                    v.y = m_Rigidbody.velocity.y;
                }

                m_Rigidbody.velocity = v;
            }
        }


        void CheckGroundStatus()
        {
            if (m_EdgePullup) // grounded if doing an edgepullup
            {
                m_GroundNormal = Vector3.up;
                m_IsGrounded = true;
                m_Animator.applyRootMotion = true;
                return;
            }

            RaycastHit hitInfo;
#if UNITY_EDITOR
            // helper to visualise the ground check ray in the scene view
            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
            // 0.1f is a small offset to start the ray from inside the character
            // it is also good to note that the transform position in the sample assets is at the base of the character
            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
            {
                m_GroundNormal = hitInfo.normal;
                m_IsGrounded = true;
                m_Animator.applyRootMotion = true;
            }
            else
            {
                m_IsGrounded = false;
                m_GroundNormal = Vector3.up;
                m_Animator.applyRootMotion = false;
            }
        }

        void OnDrawGizmosSelected()
        {
            if (!showEdgeBox)
            {
                return;
            }
            Color col = Gizmos.color;
            Gizmos.color = Color.red;
            Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position + transform.rotation * m_EdgeBoxCenter, transform.rotation, m_EdgeBoxDImensions);
            Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

            Gizmos.matrix *= cubeTransform;

            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            Gizmos.matrix = oldGizmosMatrix;
            Gizmos.color = col;
        }

    }
}

