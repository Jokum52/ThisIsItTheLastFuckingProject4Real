using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

[RequireComponent(typeof(VideoPlayer))]
public class MovieSceneLoader : MonoBehaviour
{
    public string scene;
    public float fadeOutTime = 1;
    public float fadeInTime = 1;
    public Color fadeColor = Color.black;
    public bool fadeOutVideo = true;
    public bool waitForVideoToFinish = true;
    public float delay = 1;

    VideoPlayer vP;

    private void Awake()
    {
        vP = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        vP.Play();
        StartCoroutine(QueueSceneLoad());
    }

    IEnumerator QueueSceneLoad()
    {
        yield return new WaitForSeconds(delay);
        FadedSceneLoader.LoadScene(scene, fadeColor, fadeOutTime, fadeInTime, true, true);
        float time = (float)vP.length - delay;
        if (!waitForVideoToFinish)
        {
            time -= fadeOutTime;
        }
        while(time > 0 || vP.isPlaying)
        {
            time -= Time.deltaTime;
            yield return null;

            if (!vP.isPlaying)
            {
                break;
            }
        }
        FadedSceneLoader.SetOkGo();
    }
}
