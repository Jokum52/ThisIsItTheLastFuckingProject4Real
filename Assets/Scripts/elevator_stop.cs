using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_stop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void elevatorstop()
    {

        AkSoundEngine.PostEvent("elevator_stop", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
