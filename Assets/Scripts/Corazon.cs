using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corazon : MonoBehaviour
{
    public PMOVE player;

    private void Awake()
    {
        
        player = FindObjectOfType<PMOVE>();
    }

    public void Usar()
    {

            player.HealItem(2);
            Destroy(gameObject);
    }
}
