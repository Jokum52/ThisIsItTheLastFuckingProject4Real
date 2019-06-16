using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void hammer()
    {

        AkSoundEngine.PostEvent("Hammer2", gameObject);
    }

    private void hammer2()
    {

        AkSoundEngine.PostEvent("Hammer1", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
