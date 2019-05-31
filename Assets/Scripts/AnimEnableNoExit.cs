using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnableNoExit : MonoBehaviour
{
    private Animator anim;
    public string triggererTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }





    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            anim.enabled = true;
        }
    }

  /*  void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            anim.enabled = false;
        }
    }*/





}
