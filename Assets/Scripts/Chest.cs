using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool open;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !open)
        {
            if (collision.TryGetComponent(out PMOVE player))
            {
                if(player.GetKeyAmount() > 0) 
                {
                    open = true;
                    PlayOpenAnimation();
                    player.DecreaseKeys();




                }
            }
        }
    }

    private void PlayOpenAnimation () 
    {
        _anim.Play("OpenChest");
    }
}
