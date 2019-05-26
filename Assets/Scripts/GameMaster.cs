using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame updat
    public Transform TransformPoint0;
    public Transform TransformPoint1;
    public Transform TransformPoint2;
    public Transform TransformPoint3;
    public Transform TransformPoint4;
    public Transform TransformPoint5;
    public Transform TransformPoint6;
    public Transform TransformPoint7;
    public Transform TransformPoint8;
    public Transform TransformPoint9;
    
     
   GameObject playerObject;

    

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            playerObject.transform.position = TransformPoint0.position;
            playerObject.transform.rotation = TransformPoint0.rotation;
        }
        if (Input.GetButtonDown("2"))
        {
            playerObject.transform.position = TransformPoint1.position;
            playerObject.transform.rotation = TransformPoint1.rotation;
        }
        if (Input.GetButtonDown("3"))
        {
            playerObject.transform.position = TransformPoint2.position;
            playerObject.transform.rotation = TransformPoint2.rotation;
        }
        if (Input.GetButtonDown("4"))
        {
            playerObject.transform.position = TransformPoint3.position;
            playerObject.transform.rotation = TransformPoint3.rotation;
        }
        if (Input.GetButtonDown("5"))
        {
            playerObject.transform.position = TransformPoint4.position;
            playerObject.transform.rotation = TransformPoint4.rotation;
        }
        if (Input.GetButtonDown("6"))
        {
            playerObject.transform.position = TransformPoint5.position;
            playerObject.transform.rotation = TransformPoint5.rotation;
        }
        if (Input.GetButtonDown("7"))
        {
            playerObject.transform.position = TransformPoint6.position;
            playerObject.transform.rotation = TransformPoint6.rotation;
        }
        if (Input.GetButtonDown("8"))
        {
            playerObject.transform.position = TransformPoint7.position;
            playerObject.transform.rotation = TransformPoint7.rotation;
        }
        if (Input.GetButtonDown("9"))
        {
            playerObject.transform.position = TransformPoint8.position;
            playerObject.transform.rotation = TransformPoint8.rotation;
        }
        if (Input.GetButtonDown("0"))
        {
            playerObject.transform.position = TransformPoint9.position;
            playerObject.transform.rotation = TransformPoint9.rotation;
        }

    }



    /* void OnTriggerEnter(GameObject plyr)
     {

        if (plyr.gameObject.tag == "player") ;
        {

            void OnCollisionEnter(Collider col)
            {
                if (col.gameObject.name == "deathZone0") ;
                {
                    // GetComponent.GameObject.playerObject;
                    playerObject.transform.position = TransformPoint0.position;
                    playerObject.transform.rotation = TransformPoint0.rotation;
                }
            }
        }

         }
         */
    }

    //void OnTriggerEnter(Collider plyr)
    //if (plyr.gameObject.tag == "player") ;
      //   {



