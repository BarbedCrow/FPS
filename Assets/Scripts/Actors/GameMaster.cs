using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Actor
{

    [SerializeField]
    private ActorDesc playerDesc;

    #region protected

    protected override void Start()
    {
        base.Start();

        player = Instantiate(playerDesc.Actor, playerDesc.SpawnPoint) as Player;
        player.Init(this);
        player.Activate(this);
    }

    #endregion

    #region private

    private Player player;


    #endregion
}
