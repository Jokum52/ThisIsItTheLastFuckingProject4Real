using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveReverbOnOff : MonoBehaviour
{
    public float caveReverb = 0;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetRTPCValue("cave_reverb_on_off", caveReverb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
