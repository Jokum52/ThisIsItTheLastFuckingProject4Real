using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollider : MonoBehaviour
{

    GameObject playerObject;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter(Collider playerObject)
     {

        if (playerObject.gameObject.tag == "Player") ;
        {
            
                    playerObject.transform.position = spawnPoint.position;
                    playerObject.transform.rotation = spawnPoint.rotation;
            
        }

     }
}
