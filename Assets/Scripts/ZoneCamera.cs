using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Awake()
    {
        _camera= GetComponent<CinemachineVirtualCamera>();
    }

    public int currentZone;

    public void SetPriority(int priority)
    {
        _camera.Priority = priority;
    }
}
