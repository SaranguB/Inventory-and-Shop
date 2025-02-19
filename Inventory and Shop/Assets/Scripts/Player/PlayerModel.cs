using System;
using UnityEngine;

public class PlayerModel
{
    PlayerController PlayerController;
    public int numberOfCoins;

    public PlayerModel()
    {
        numberOfCoins = 0;
    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.PlayerController = playerController;
    }
}
