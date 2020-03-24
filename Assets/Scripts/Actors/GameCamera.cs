using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : Actor
{

    [SerializeField] private Vector3 offset;
    
    protected override void InitInternal()
    {
        base.InitInternal();

        player = GameMaster.GetGameMaster().Player.transform;
    }

    protected override void Update()
    {
        base.Update();

        transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);
    }

    private Transform player;

}
