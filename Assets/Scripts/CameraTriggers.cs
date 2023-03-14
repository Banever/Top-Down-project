using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTriggers : MonoBehaviour
{
    public GameObject Camtrigger;
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineVirtualCamera virtualCamera2;
    public float TT = 2;
    public bool IT;
    private float CTT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            VirtualCamera.Priority = 1;
            virtualCamera2.Priority = 0;
            IT = true;

        }
        
    }

    void SetPriority(int Priority)
    {
         VirtualCamera.Priority = Priority;
    }

    private void Update()
    {
        CTT += Time.deltaTime;
    }
    


}
