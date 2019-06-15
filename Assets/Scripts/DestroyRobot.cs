using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRobot : MonoBehaviour


   // public GameObject otherObject;
{

    /* void OnCollisionEnter(Collision other)

     {

         if (other.gameObject.tag.Equals("Player"))

         {

             gameObject.SetActive(false);

         }
         */

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RobotWalker")
        {
            Object.Destroy(gameObject, 1.0f);

        }


    }
}