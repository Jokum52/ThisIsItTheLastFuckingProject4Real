using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{
    public Animator anim;
    //  public GameObject lightningStrike;
    public float timer = 2f;
    public bool timerStart = false;
   // private bool slowMo = false;

    void Start()
    {
        //lightning = GameObject.FindGameObjectWithTag("lightning");
        //  lightningStrike.gameObject.SetActive(false);
      //  bool slowMo = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

                AkSoundEngine.PostEvent("thunder", gameObject);

            


            Time.timeScale = 0.3f;
           // Time.fixedDeltaTime = 0.02f * Time.timeScale;
            anim.SetTrigger("Light");
            //  lightningStrike.gameObject.SetActive(true);
            //timer -= Time.deltaTime;
            //Debug.Log("DonaldTrump");
                timerStart = true;
           // bool slowMo = true;
            Debug.Log("SlowMo_Activate");
            


        }
    }

    /* {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.7f;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    /* void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            bool timerStart = true;
            //lightning.gameObject.SetActive(false);
        }
    }*/



    void Update()
    {

        if (timerStart == true)
        {
           
            timer -= Time.deltaTime;
            Debug.Log("SlowMo");

            if (timer <= 0)
            {
               // bool slowMo = false;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Debug.Log("SlowMo_False");
                timerStart = false;
                // lightningStrike.gameObject.SetActive(false);
                //Debug.Log("NoCollusion");

            }
        }

       
        /*
        if  (timerStart == true)
        {
                   
                timer -= Time.deltaTime;

                        if (timer <= 0)
                                  {
                 timerStart = false;
                                        lightningStrike.gameObject.SetActive(false);
                                        //Debug.Log("NoCollusion");
               
                                  }

        }
        

        /* if (timerStart)
             {
                 timer -= Time.deltaTime;
             lightningStrike.gameObject.SetActive(true);
                  Debug.Log ("start");
              }
      */

        //lightning.gameObject.SetActive(false);

    }
   /* void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            lightning.gameObject.SetActive(false);
            //lightning.gameObject.SetActive(false);
        }
    }*/

    

}