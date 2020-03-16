using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Actor
{

    [SerializeField]
    private ActorDesc PlayerDesc;

    public Player Player { get; private set; }

    public static GameMaster GetGameMaster()
    {
        return GameObject.FindGameObjectWithTag(Tags.GAME_MASTER).GetComponent<GameMaster>();
    }
    
    #region protected

    protected override void Start()
    {
        base.Start();

        Player = Instantiate(PlayerDesc.Actor, PlayerDesc.SpawnPoint) as Player;
        Player.Init(this);
        Player.Activate(this);

        hudManager = GetComponent<HudManager>();
        hudManager.Init();
        hudManager.Enable();
    }

    #endregion

    #region private

    private HudManager hudManager;

    #endregion
}
