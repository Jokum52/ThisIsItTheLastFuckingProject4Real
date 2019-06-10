using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnetoOne : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerObject;
  

    // Start is called before the first frame update
    void Start()
    {
       // playerObject = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("1"))
        {

            SceneManager.LoadScene("Act_1.1");

        }


        if (Input.GetButtonDown("2"))
        {

            SceneManager.LoadScene("Act_1.1_KillingTheRat");

        }

        if (Input.GetButtonDown("3"))
        {

            SceneManager.LoadScene("Act_1.2");

        }


        if (Input.GetButtonDown("4"))
        {

            SceneManager.LoadScene("Act2_2.0");

        }


        if (Input.GetButtonDown("5"))
        {

            SceneManager.LoadScene("Act2_2.0_Killing_The_Admin");

        }

     
        if (Input.GetButtonDown("6"))
        {

            SceneManager.LoadScene("Act3_Scene_0.1");

        }

        if (Input.GetButtonDown("7"))
        {

            SceneManager.LoadScene("Act3_0.2");

        }

        if (Input.GetButtonDown("8"))
        {

            SceneManager.LoadScene("Act4GrayboxingStuff");

        }

    }
   /* void OnTriggerEnter(Collider playerObject)
    {

        if (playerObject.gameObject.tag == "Player") ;
        {

            SceneManager.LoadScene("Act_1.2");

         
        }


    }
    */
}

