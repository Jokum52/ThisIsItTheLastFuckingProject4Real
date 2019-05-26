using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAct1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetSwitch("Music_switch", "Chase", gameObject);

        AkSoundEngine.SetSwitch("Chase_switch", "Intro", gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
