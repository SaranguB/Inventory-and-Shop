using System;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private TextMeshProUGUI playerCoinCountText;
    [SerializeField] private TextMeshProUGUI playerBagWeightText;
    [SerializeField] private TextMeshProUGUI playerBagCapacityText;


    private void OnDisable()
    {
        EventService.Instance.onItemSoldWithFloatParams.AddListener(playerController.SetBagWeight);
        EventService.Instance.onItemSoldWithIntParams.RemoveListener(playerController.SetPlayerCoin);

    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        SetCoinText();
        SetPlayerBagCapacityText();
        SetBagWeightText();
        EventService.Instance.onItemSoldWithIntParams.AddListener(playerController.SetPlayerCoin);
        EventService.Instance.onItemSoldWithFloatParams.AddListener(playerController.SetBagWeight);


    }

    public void SetCoinText()
    {
        playerCoinCountText.text = playerController.GetPlayerCoinCount().ToString();
    }

    public void SetBagWeightText()
    {
        playerBagWeightText.text = playerController.GetBagWeight().ToString();
    }

    public void SetPlayerBagCapacityText()
    {
        playerBagCapacityText.text = " / " + playerController.GetBagCapacity().ToString() + " kg";
    }
}
