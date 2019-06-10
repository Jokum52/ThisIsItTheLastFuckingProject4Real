using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceGravel : MonoBehaviour
{

    public GameObject player;
    public GameObject point_gravel;
    public float distance_gravel;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        distance_gravel = Vector3.Distance(player.transform.position, point_gravel.transform.position);

        AkSoundEngine.SetRTPCValue("gravel", distance_gravel);
        AkSoundEngine.SetRTPCValue("mud", distance_gravel);
        Debug.Log("distance is " + distance_gravel);
    }


}
