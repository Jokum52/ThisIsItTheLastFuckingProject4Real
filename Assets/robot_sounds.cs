using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_sounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void robot_steam()
    {

        AkSoundEngine.PostEvent("robot_steam", gameObject);

    }

    private void robot_startup()
    {

        AkSoundEngine.PostEvent("robot_start_up", gameObject);

    }

    private void robot_walk()
    {

        AkSoundEngine.PostEvent("robot_walk", gameObject);

    }

    private void robot_load_gun()
    {

        AkSoundEngine.PostEvent("robot_load_gun", gameObject);

    }

    private void robot_shoot_gun()
    {

        AkSoundEngine.PostEvent("robot_shoot_gun", gameObject);

    }

    private void robot_gun_cool_off()
    {

        AkSoundEngine.PostEvent("robot_gun_cool_off", gameObject);

    }

    private void robot_turn()
    {

        AkSoundEngine.PostEvent("robot_turn", gameObject);

    }

    private void robot_creak()
    {

        AkSoundEngine.PostEvent("robot_creak", gameObject);

    }

    private void robot_shut_down()
    {

        AkSoundEngine.PostEvent("robot_shut_down", gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
