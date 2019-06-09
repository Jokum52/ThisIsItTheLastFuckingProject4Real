using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveRTPCOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetRTPCValue("cave_reverb_on_off", 0, gameObject);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
