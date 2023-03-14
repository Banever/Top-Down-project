using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;

public class Currentcamera : MonoBehaviour
{
    private CinemachineVirtualCamera _Vcamera;
    private int currentcamera;


    private void Awake()
    {
        _Vcamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void SetPriority(int Priority)
    {
        _Vcamera.Priority = Priority;
    }
}
