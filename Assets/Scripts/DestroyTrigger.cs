using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
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
        if (other.tag == "Player")

            Object.Destroy(gameObject, 0.5f);

    }
}