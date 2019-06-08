using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFootstepReverb : MonoBehaviour
{
    public GameObject player;
    public GameObject point_reverb;
    public float distance_reverb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        distance_reverb = Vector3.Distance(player.transform.position, point_reverb.transform.position);

        AkSoundEngine.SetRTPCValue("footstep_reverb", distance_reverb);
        Debug.Log("distance is " + distance_reverb);
    }


}