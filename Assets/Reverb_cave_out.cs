using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverb_cave_out : MonoBehaviour
{
    public GameObject player;
    public GameObject point_reverb;
    public float distance_out_reverb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        distance_out_reverb = Vector3.Distance(player.transform.position, point_reverb.transform.position);

        AkSoundEngine.SetRTPCValue("cave_reverb_out", distance_out_reverb);
        Debug.Log("distance out is " + distance_out_reverb);
    }


}