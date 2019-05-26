using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTwotoThree : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerObject;
   // public float timer = 10f;
   // bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (isTriggered == true)
        {
            timer -= Time.deltaTime;
        }
       
        if (timer <= 5f)
        {

            //  ><
            SceneManager.LoadScene("3");
        }
        if (timer == 0f)
        {
            isTriggered = false;
        }
        */
    }
    void OnTriggerEnter(Collider playerObject)
    {

        if (playerObject.gameObject.tag == "Player") ;
        {

            SceneManager.LoadScene("Act3_Scene_0.1");

            /*   if (!isTriggered)
               {
                   isTriggered = true;
                   print("new scene Triggered!");
                   //LoadSceneMode.Additive
               }*/

        }


    }
}

/*
 public AudioClip alertLoop;
float timer = 3f;
bool isTriggered = false;

public void OnTriggerEnter(Collider col)
{
    if(!isTriggered)
    {
        isTriggered = true;
        AudioManager.instance.PlayOneShot(alertLoop);
        print("Alarm Triggered!");
    }

}
public void OnTriggerExit(Collider col)
{
    timer -= Time.deltaTime;
    if(timer == 0)
    {
        isTriggered = false;
    }
}
 */
