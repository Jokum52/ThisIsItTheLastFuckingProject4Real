using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weldersounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void svejs()
    {

        AkSoundEngine.PostEvent("Svejs", gameObject);
    }

    private void svejsOff()
    {

        AkSoundEngine.PostEvent("SvejsOff", gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
