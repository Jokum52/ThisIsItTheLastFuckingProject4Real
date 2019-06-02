using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsReverb : MonoBehaviour
{
    public GameObject player;
    public GameObject point1;
    public float distance1_;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        distance1_ = Vector3.Distance(player.transform.position, point1.transform.position);

        AkSoundEngine.SetRTPCValue("cave_birds", distance1_);
        //Debug.Log("distance is " + distance1_);
    }


}