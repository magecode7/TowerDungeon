using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text text = null;
    private Player player;

    void Start()
    {
        UpdateVisual();
    }

    void LateUpdate()
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        player = Player.player;
        if (player)
        {
            text.text = $"{player.Money}$";
        }
        else text.text = "No player!";
    }
}
