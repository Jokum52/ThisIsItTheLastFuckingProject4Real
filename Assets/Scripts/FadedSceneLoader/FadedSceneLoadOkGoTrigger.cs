using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedSceneLoadOkGoTrigger : MonoBehaviour
{
    public string triggererTag = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            FadedSceneLoader.SetOkGo();
        }
    }
}
