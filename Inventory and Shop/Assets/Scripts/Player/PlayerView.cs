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
        EventService.Instance.onItemChangedWithFloatParams.RemoveListener(playerController.SetBagWeight);
        EventService.Instance.onItemBroughtWithIntParams.RemoveListener(playerController.DecreasePlayerCoin);

        EventService.Instance.onItemSoldWithIntParams.RemoveListener(playerController.IncreasePlayerCoin);

    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        SetCoinText();
        SetPlayerBagCapacityText();
        SetBagWeightText();
        EventService.Instance.onItemBroughtWithIntParams.AddListener(playerController.DecreasePlayerCoin);
        EventService.Instance.onItemSoldWithIntParams.AddListener(playerController.IncreasePlayerCoin);

        EventService.Instance.onItemChangedWithFloatParams.AddListener(playerController.SetBagWeight);


    }

    public void SetCoinText()
    {
        playerCoinCountText.text = playerController.GetPlayerCoinCount().ToString();
    }

    public void SetBagWeightText()
    {
        playerBagWeightText.text = playerController.GetBagWeight().ToString("0.#");
    }

    public void SetPlayerBagCapacityText()
    {
        playerBagCapacityText.text = " / " + playerController.GetBagCapacity().ToString() + " kg";
    }
}
