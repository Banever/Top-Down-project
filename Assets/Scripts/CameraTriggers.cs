using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraTriggers : MonoBehaviour
{
    public GameObject Camtrigger;
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineVirtualCamera virtualCamera2;
    public PMOVE player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            VirtualCamera.Priority = 1;
            virtualCamera2.Priority = 0;
            StartCoroutine(TriggerWait());
        }
    }

    void SetPriority(int Priority)
    {
         VirtualCamera.Priority = Priority;
    }

    IEnumerator TriggerWait()
    {
        Camtrigger.SetActive(false);
        yield return new WaitForSeconds(4);
        Camtrigger.SetActive(true);

    }
}
