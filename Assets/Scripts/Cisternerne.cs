using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cisternerne : MonoBehaviour
{

    public GameObject player;
    public GameObject point2;
    public float distance2_;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        distance2_ = Vector3.Distance(player.transform.position, point2.transform.position);
        
        //AkSoundEngine.SetRTPCValue("wind_cave_opening", distance2_);
       //Debug.Log("distance is " + distance2_);
    }


}
