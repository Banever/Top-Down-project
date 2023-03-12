using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChangeTrigger : MonoBehaviour
{
    public int currentZone;
    public int nextZone;

    public ZoneManager zoneManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zoneManager.OnPlayerEntered(currentZone, nextZone);
        }
    }
}
