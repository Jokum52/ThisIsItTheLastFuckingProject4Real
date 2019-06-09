using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOther : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enable;

    void Start()
    {
      //  other.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

            enable.gameObject.SetActive(true);

    }
}
