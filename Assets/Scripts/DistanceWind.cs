using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWind : MonoBehaviour{

    public GameObject player;
    public GameObject point;
    public float distance_;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        distance_ = Vector3.Distance(player.transform.position, point.transform.position);

        //AkSoundEngine.SetRTPCValue("wind_cave_opening", distance_);
        //Debug.Log("distance is " + distance_);
    }

    
}
