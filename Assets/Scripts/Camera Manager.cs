using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera CannonAimCam;
    [SerializeField] CinemachineVirtualCamera bullettimeCam;
    [SerializeField] GameObject CannonBall;

    private void Update()
    {
        if (Input.GetKey(KeyCode.C)) 
        {
            bullettimeCam.Priority = 100;
            CannonAimCam.Priority = 0;
            bullettimeCam.LookAt = CannonBall.transform;
            bullettimeCam.Follow = CannonBall.transform;
        }else
        {
            CannonAimCam.Priority = 100;
            bullettimeCam.Priority = 0;
        }
            
    }


}
