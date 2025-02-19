using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private TextMeshProUGUI playerCoinCountText;

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        playerCoinCountText.text = playerController.GetPlayerCoinCount().ToString();

    }

}
