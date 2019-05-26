using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Cinemachine;
using UnityEngine.Profiling;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonPathUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        private float currentPathPosition;

        public CinemachinePathBase path;
        public float pathDistanceTolerance = 0.1f;
        public float pathDistanceSteering = 1f;

        public AnimationCurve adjustedInput = new AnimationCurve(new Keyframe[2] { new Keyframe(0, 0), new Keyframe(1, 1) });


        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

            currentPathPosition = path.FindClosestPoint(transform.position, 0, -1, 5);
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            Profiler.BeginSample("Character Controller Pathing");
            int startPos = Mathf.FloorToInt(currentPathPosition) - 1;
            if (startPos < 0)
                startPos = 0;
            currentPathPosition = path.FindClosestPoint(transform.position, startPos, 3, 5);
            Vector3 closestPoint = path.EvaluatePosition(currentPathPosition);
            Vector3 tangent = path.EvaluateTangent(currentPathPosition);
            tangent.y = 0;
            tangent.Normalize();
            
            Vector3 targetDir = tangent;

            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            h = adjustedInput.Evaluate(Mathf.Abs(h)) * Mathf.Sign(h);
            v = adjustedInput.Evaluate(Mathf.Abs(v)) * Mathf.Sign(v);

            // Correction when too far away from path
            closestPoint.y = 0;
            Vector3 pos = transform.position;
            pos.y = 0;
            Vector3 dirToPath = (closestPoint - pos);
            dirToPath.y = 0;
            float pathDist = dirToPath.magnitude;
            pathDist -= pathDistanceTolerance;
            dirToPath.Normalize();
            Debug.DrawLine(closestPoint, closestPoint + tangent * 3);

            if (pathDist > 0)
            {
                if (h < 0)
                {
                    dirToPath = -dirToPath;
                }
                targetDir = Vector3.Lerp(tangent, dirToPath, pathDist * pathDistanceSteering);
            }

            Profiler.EndSample();


            m_Move = targetDir * h;
            bool crouch = Input.GetKey(KeyCode.C);

//            // calculate move direction to pass to character
//            if (m_Cam != null)
//            {
//                // calculate camera relative direction to move:
//                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
//                m_Move = v * m_CamForward + h * m_Cam.right;
//            }
//            else
//            {
//                // we use world-relative directions in the case of no main camera
//                m_Move = v * Vector3.forward + h * Vector3.right;
//            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif


            // add vertical input
            m_Move.y = v;

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
