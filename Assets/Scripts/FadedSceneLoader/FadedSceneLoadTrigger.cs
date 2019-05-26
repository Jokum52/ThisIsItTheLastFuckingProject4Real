using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FadedSceneLoadTrigger : MonoBehaviour
{
    public string scene;
    public bool fadeIn = true;
    public float fadeOutTime = 1;
    public float fadeInTime = 1;
    public Color fadeColor = Color.black;
    public string triggererTag = "Player";
    public bool waitForOkGo = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggererTag))
        {
            FadedSceneLoader.LoadScene(scene, fadeColor, fadeOutTime, fadeInTime, fadeIn, waitForOkGo);
        }
    }
}
