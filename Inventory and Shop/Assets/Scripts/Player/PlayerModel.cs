using System;
using UnityEngine;

public class PlayerModel
{
    PlayerController PlayerController;
    public int numberOfCoins;
    public float bagWeight;
    public float bagCapacity;
    public PlayerModel()
    {
        numberOfCoins = 0;
        bagWeight = 0;
        bagCapacity = 25;
    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.PlayerController = playerController;
    }
}
