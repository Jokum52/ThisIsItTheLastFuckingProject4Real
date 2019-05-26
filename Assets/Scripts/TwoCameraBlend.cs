using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider), typeof(CinemachineMixingCamera))]
public class TwoCameraBlend : MonoBehaviour
{
    enum Axis
    {
        XAxis,
        YAxis,
        ZAxis
    }

    [SerializeField] Axis mode;

    CinemachineMixingCamera mixingCamera;
    BoxCollider BC;
    Transform target;

    float boxWidth;
    float interpolatedPosition;


    private void Start()
    {
        mixingCamera = GetComponent<CinemachineMixingCamera>();
        BC = GetComponent<BoxCollider>();

        BC.isTrigger = true;
        switch (mode)
        {
            case (Axis.XAxis):
                boxWidth = BC.size.x / 2;
                break;

            case (Axis.YAxis):
                boxWidth = BC.size.y / 2;
                break;

            case (Axis.ZAxis):
                boxWidth = BC.size.z / 2;
                break;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            switch (mode)
            {
                case (Axis.XAxis):
                    interpolatedPosition = Mathf.InverseLerp(transform.position.x - boxWidth, transform.position.x + boxWidth, target.position.x);
                    break;

                case (Axis.YAxis):
                    interpolatedPosition = Mathf.InverseLerp(transform.position.y - boxWidth, transform.position.y + boxWidth, target.position.y);
                    break;

                case (Axis.ZAxis):
                    interpolatedPosition = Mathf.InverseLerp(transform.position.z - boxWidth, transform.position.z + boxWidth, target.position.z);

                    break;
            }

            mixingCamera.SetWeight(0, interpolatedPosition);
            mixingCamera.SetWeight(1, 1 - interpolatedPosition);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        target = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        target = null;
    }
}
