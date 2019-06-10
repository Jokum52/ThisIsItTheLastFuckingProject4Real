using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRayCarsten : MonoBehaviour
{
    Ray rayCumLord;
    public Color cumColor;
    RaycastHit cumHit;
    bool playerHitByCum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rayCumLord = new Ray(transform.position, transform.forward * 30);
        Debug.DrawRay(transform.position, transform.forward * 30, cumColor);


        if (Physics.Raycast(transform.position, transform.forward, 30));
        {
            playerHitByCum=true;
        }
    }
}
