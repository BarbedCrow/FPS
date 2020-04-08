using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiRotation : AiAction
{

    [SerializeField] private float angleTolerance;

    protected override bool TryToExecuteInternal()
    {
        var playerTransform = player.transform;
        var playerPos = new Vector2(playerTransform.position.x, playerTransform.position.z);
        var scannerPos = new Vector2(transform.position.x, transform.position.z);
        var dir = playerPos - scannerPos;
        var forward2d = new Vector2(transform.forward.x, transform.forward.z);
        var angle = Vector2.Angle(forward2d, dir);
        if (angle < angleTolerance) return false;

        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.y));
        
        return true;
    }

    protected override void InitInternal()
    {
        base.InitInternal();

        visibilitySensor = GetComponent<AiVisibilitySensor>();
        navAgent = GetComponent<NavMeshAgent>();
        player = GameMaster.GetGameMaster().Player;
    }

    private AiVisibilitySensor visibilitySensor;
    private NavMeshAgent navAgent;
    private Player player;
}
