using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Destroy()
    {
        Object.Destroy(gameObject, 0.0f);
    }
}
