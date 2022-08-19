using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image image = null;
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
            image.fillAmount = player.Damageable.Health / player.Damageable.MaxHealth;
            text.text = $"{player.Damageable.Health}/{player.Damageable.MaxHealth}";
        }
        else text.text = "No player!";
    }
}
