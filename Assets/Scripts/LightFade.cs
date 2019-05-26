using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFade : MonoBehaviour
{
    public float minDistance = 1;
    public float maxDistance = 5;
    public float minIntensity = 0;
    public float maxIntensity = 1;
    public AnimationCurve distanceBlend;

    Light mylight;
    Transform player;
    Color originalCol;

    private void Start()
    {
        mylight = GetComponent<Light>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject == null)
        {
            Debug.LogError("Object with Player tag could not be found, required for FadeLight");
        }
        player = playerObject.transform;
        originalCol = mylight.color;
    }

    private void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        // map to normalized distance
        float normalizedDistance = Mathf.Clamp01((distToPlayer - minDistance) / (maxDistance - minDistance));
        // map distance to Intensity
        float normalizedIntensity = (1 - normalizedDistance);
        normalizedIntensity = distanceBlend.Evaluate(normalizedIntensity);
        float targetIntensity = normalizedIntensity * (maxIntensity - minIntensity) + minIntensity;

        mylight.color = new Color(normalizedIntensity * originalCol.r, normalizedIntensity * originalCol.g, normalizedIntensity * originalCol.b, normalizedIntensity * originalCol.a);

        AkSoundEngine.SetRTPCValue("seagull_reverb", normalizedDistance);

       
    }

    private void OnDrawGizmosSelected()
    {
        Color col = Gizmos.color;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
        Gizmos.color = col;
    }
}
