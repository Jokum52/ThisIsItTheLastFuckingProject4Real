using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnableDisable : MonoBehaviour
{
    //private Animator anim;
    public string triggererTag = "Player";

    public GameObject lights;
    // Start is called before the first frame update
    void Start()
    {
        lights.SetActive(false);
       // anim = GetComponent<Animator>();
       // anim.enabled = false;
    }





    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            // anim.enabled = true;
            lights.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            //anim.enabled = false;
            lights.SetActive(false);
        }
    }





}
