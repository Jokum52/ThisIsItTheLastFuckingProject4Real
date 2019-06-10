using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudRTPC : MonoBehaviour
{
    public float mudRTPC = 10; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

            AkSoundEngine.SetRTPCValue("mud", mudRTPC); ;

    }
}
