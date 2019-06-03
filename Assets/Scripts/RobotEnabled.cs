using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStart : MonoBehaviour
{
    //private Animator anim;
    public string triggererTag = "Player";
    public Animator anim;
    //public GameObject anim;
    //  public GameObject animLight;

    // public GameObject lights;
    // Start is called before the first frame update
    void Start()
    {
        //lights.SetActive(false);
        anim = GetComponentInChildren<Animator>();

        GetComponent<Animator>().enabled = false;
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
            GetComponent<Animator>().enabled = true;
            // anim.enabled = true;
            //    lights.SetActive(true);

        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            //anim.enabled = false;
         //   lights.SetActive(false);
        }
    }*/





}
