using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private PlayerModel playerModel;

    public PlayerController(PlayerView playerView, PlayerModel playerModel)
    {
        this.playerView = playerView;
        this.playerModel = playerModel;

        this.playerView.SetPlayerController(this);
        this.playerModel.SetPlayerController(this);
    }

    public int GetPlayerCoinCount()
    {
        //Debug.Log(playerModel.numberOfCoins);
        return playerModel.numberOfCoins;
    }
}
