using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownRobot : MonoBehaviour
{

    public GameObject otherObject;
    public Animator otherAnimator;
    public Animator otherAnimator2;
   // Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponentInChildren<Animator>();

        // GetComponent<Animator>().enabled = false;
    }
    
    void Awake()
    {
        otherAnimator = otherObject.GetComponent<Animator>();
        otherAnimator2 = otherObject.GetComponent<Animator>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {

            otherAnimator.SetBool("Deactivate", true);
            otherAnimator2.SetBool("Deactivate", true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
