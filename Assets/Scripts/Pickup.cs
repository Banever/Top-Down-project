using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventario Inventario;
    public GameObject itemButton;

    private void Start()
    {
        Inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < Inventario.Slots.Length; i++)
            {
                if (Inventario.isFull[i] == false)
                {
                    Inventario.isFull[i] = true;
                    Instantiate(itemButton, Inventario.Slots[i].transform, false);
                    Destroy(gameObject);
                    break;                   
                }
            }
        }
    }
}
