using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void musicIntro()
    {

        AkSoundEngine.SetState("Chase", "Intro");
    }

    private void musicMain()
    {

        AkSoundEngine.SetState("Chase", "Main");
    }

    private void windowCrush()
    {

        AkSoundEngine.PostEvent("window_crush", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
