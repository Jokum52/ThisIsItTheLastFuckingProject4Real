using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRayCarsten : MonoBehaviour
{
    Ray rayCumLord;
    public Color cumColor;

    public GameObject playerAlive;
    public GameObject playerSplatt;
    public GameObject playerObject;
    public Transform spawnPoint;

    public bool reSpawn = false;

    public float timer = 3f;
    public bool timerStart = false;

    //  bool playerHitByCum;

    // float hitForce;
    // Start is called before the first frame update
    void Start()
    {
        playerAlive.SetActive(true);
        playerSplatt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        Ray rayCumLord = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 500f, cumColor);
        RaycastHit hit;
        if(Physics.Raycast(rayCumLord,out hit,500f))
        {
            Debug.Log("I'd want to hit you but i missed :(");
            if (hit.collider.CompareTag("Player"))
            {

                playerAlive.SetActive(false);
                playerSplatt.SetActive(true);
                Debug.Log("I hit ya booty!");
             
                timerStart = true;


            }
        }

        if (timerStart == true)
        {

            timer -= Time.deltaTime;
          

            if (timer <= 0)
            {
                // bool slowMo = false;


                reSpawn = true;
                timerStart = false;
                // lightningStrike.gameObject.SetActive(false);
                //Debug.Log("NoCollusion");

            }
        }

        if (timerStart == false)
        {

            timer = 3f;
            playerAlive.SetActive(true);
            playerSplatt.SetActive(false);
        

        }

        if (reSpawn == true)
        {

         
            playerObject.transform.position = spawnPoint.position;
            playerObject.transform.rotation = spawnPoint.rotation;
            reSpawn = false;


        }


    }
}
