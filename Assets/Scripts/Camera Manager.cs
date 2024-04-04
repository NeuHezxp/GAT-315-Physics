using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera CannonAimCam;
    [SerializeField] CinemachineVirtualCamera bullettimeCam;

    public void TrackObject(GameObject target)
    {
        bullettimeCam.LookAt = target.transform;
        bullettimeCam.Follow = target.transform;
        bullettimeCam.Priority = 100;
        CannonAimCam.Priority = 0;
        SlowDownTime();
    }

    public void StopTracking()
    {
        CannonAimCam.Priority = 100;
        bullettimeCam.Priority = 0;

        ResetTimeScale();
    }
    void SlowDownTime()
    {
        Time.timeScale = 0.5f; // Half the normal speed; 
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // keeps fixed delta time at normal speed
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1.0f; // Reset to normal speed
        Time.fixedDeltaTime = 0.02f; // Reset fixed delta time
    }
}
