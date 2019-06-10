using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraEnding : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    public void ChangeCamera()
    {

        camera.Priority = 2000;

    }

}
