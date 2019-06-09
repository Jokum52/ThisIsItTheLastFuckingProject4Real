using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAnims : MonoBehaviour
{

    public GameObject otherObject;
    public Animator otherAnimator;
    public GameObject otherObject2;
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
        otherAnimator2 = otherObject2.GetComponent<Animator>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
            otherAnimator.SetTrigger("End");
            otherAnimator2.SetTrigger("KillPortal");
           

        }
    }

  

    
}
