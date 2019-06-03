using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShootingRobot : MonoBehaviour
{


    Animator m_Animator;


    // Start is called before the first frame update
    void Start()
    {

        m_Animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {

            m_Animator.SetBool("Activate", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
