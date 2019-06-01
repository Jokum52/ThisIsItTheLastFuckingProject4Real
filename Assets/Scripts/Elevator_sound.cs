using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void elevatorstart()
    {

        AkSoundEngine.PostEvent("elevator_start", gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
