using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : SingleTon<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCameral;

    private void Start() {
        SetPlayerCameraFollow();
    }

    public void SetPlayerCameraFollow(){
        cinemachineVirtualCameral=FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCameral.Follow=PlayerController.Instance.transform;

    }
}
