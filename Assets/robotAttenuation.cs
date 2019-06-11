using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotAttenuation : MonoBehaviour
{
    public float RobotAttenuation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("robot_attenuation", RobotAttenuation);
    }
}
