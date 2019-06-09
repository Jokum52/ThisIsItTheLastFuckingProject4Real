using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Footsteps() {

        AkSoundEngine.PostEvent("Footstep", gameObject);
            
    }

    private void WalkClothes()
    {

        AkSoundEngine.PostEvent("walk_clothes", gameObject);
    }

    private void ClimbFootstep()
    {

        AkSoundEngine.PostEvent("footstep_climb", gameObject);
    }

    private void PullUp()
    {

        AkSoundEngine.PostEvent("Pull_up", gameObject);
    }

    private void Jump()

    {

        AkSoundEngine.PostEvent("jump", gameObject);
    }

    private void Shoot()
    {

        AkSoundEngine.PostEvent("gun_shot", gameObject);
    }


    private void Unholster()
    {

        AkSoundEngine.PostEvent("gun_unholster", gameObject);


    }


    private void Holster()
    {
        AkSoundEngine.PostEvent("gun_holster", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
