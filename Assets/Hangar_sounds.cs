using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar_sounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void shutters()
    {

        AkSoundEngine.PostEvent("shutters", gameObject);
    }

    private void hanger_lights()
    {

        AkSoundEngine.PostEvent("hangar_light", gameObject);
    }

    private void alarm()
    {

        AkSoundEngine.PostEvent("alarm", gameObject);
    }

    private void tesla_coil()
    {

        AkSoundEngine.PostEvent("tesla_coil", gameObject);
    }

    private void Alarm_off()
    {

        AkSoundEngine.PostEvent("Alarm_end", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
