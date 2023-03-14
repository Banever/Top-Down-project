using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public bool open;
    public Transform chest;
    public GameObject ItemPrefab;

    void OnTriggerEnter2D(Collider2D Collider)
    {

        if(Collider.CompareTag("Player") && !open)
        {
            if (Collider.TryGetComponent(out PMOVE player))
            {

                if (player.GetKeyAmount() > 0)
                {
                    open = true;
                    player.DecreaseKeys();
                    Instantiate(ItemPrefab, chest.position, chest.rotation);
                }
            }
        }
    }
}
