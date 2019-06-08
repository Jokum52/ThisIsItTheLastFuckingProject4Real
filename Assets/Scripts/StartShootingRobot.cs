using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShootingRobot : MonoBehaviour
{

    public GameObject otherObject;
    public Animator otherAnimator;
    Animator m_Animator;


    // Start is called before the first frame update
    void Start()
    {

        m_Animator = GetComponent<Animator>();
    }


    void Awake()
    {
        otherAnimator = otherObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {

            m_Animator.SetBool("Activate", true);
          //  otherAnimator.SetBool("Acctivate", true);
        }
    }

    public void StartRobot()
    {

        otherAnimator.SetBool("Activate", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
