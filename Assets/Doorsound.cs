using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Hangar_door()
    {

        AkSoundEngine.PostEvent("Hangar_door_out", gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
