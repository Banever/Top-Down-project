using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform chest;
    public GameObject ItemPrefab;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        Instantiate(ItemPrefab, chest.position, chest.rotation);
    }
}
