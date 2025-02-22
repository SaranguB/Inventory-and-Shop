using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private TextMeshProUGUI playerCoinCountText;


    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        EventService.Instance.onItemSoldWithParams.RemoveListener(playerController.SetPlayerCoin);

    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        SetCoinText();
        EventService.Instance.onItemSoldWithParams.AddListener(playerController.SetPlayerCoin);


    }

    public void SetCoinText()
    {
        playerCoinCountText.text = playerController.GetPlayerCoinCount().ToString();
    }
}
