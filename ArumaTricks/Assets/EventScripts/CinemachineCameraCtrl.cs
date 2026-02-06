using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CinemachineCameraCtrl : MonoBehaviour
{
   // [SerializeField] CinemachineVirtualCamera[] vcams;
    [SerializeField] CinemachineCamera[] ccams;

    int nowCameraIndex = 0;

    public void changeCamera(int camIndex)
    {
        nowCameraIndex = camIndex;
        for (int i = 0; i < ccams.Length; i++)
        {
            if(i == camIndex)
            {
                ccams[i].Priority = 1;
            }
            else
            {
                ccams[i].Priority = 0;
            }
        }
    }

    int saveedCameraIndex = 0;
    public void SaveCameraIndex(){
        saveedCameraIndex = nowCameraIndex;
    }
    public void LoadCameraIndex(){
        changeCamera(saveedCameraIndex);
    }
}
