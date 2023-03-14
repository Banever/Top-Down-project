using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PMOVE player;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        player.OnKeyAmountChanged += Player_OnKeyAmountChanged;
    }

    private void Player_OnKeyAmountChanged()
    {
        text.text = player.GetKeyAmount().ToString();
        player.ToString();
    }
}
