using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField] private Image image = null;
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
            image.fillAmount = player.DashMovement.DashCooldown;
        }
    }
}
