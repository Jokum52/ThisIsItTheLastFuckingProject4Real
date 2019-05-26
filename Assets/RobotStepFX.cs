using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStepFX : MonoBehaviour
{
    public GameObject[] fxList;
    public GameObject fxPrefab;
    public GameObject rightFoot;
    public GameObject leftFoot;
   
    public void RightStepFx()
    {
        
        
        GameObject _instantiatedFX = Instantiate(fxPrefab, rightFoot.transform.position, rightFoot.transform.rotation) as GameObject;
    }

    public void LeftStepFx()
    {
        GameObject _instantiatedFX = Instantiate(fxPrefab, leftFoot.transform.position, leftFoot.transform.rotation) as GameObject;
    }
    
    public void RightStepRandomfx()
    {
        GameObject _instantiatedFX = Instantiate(fxList[Random.Range(0, fxList.Length)], rightFoot.transform.position, rightFoot.transform.rotation) as GameObject;
    }

    public void LeftStepRandomfx()
    {
        GameObject _instantiatedFX = Instantiate(fxList[Random.Range(0,fxList.Length)], leftFoot.transform.position, leftFoot.transform.rotation) as GameObject;
    }
}
