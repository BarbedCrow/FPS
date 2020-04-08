using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : AiAction
{

    [SerializeField] private float safeDistance;

    public float SafeDistance { get { return safeDistance; } private set { } }

    protected override bool TryToExecuteInternal()
    {
        if (!visibilitySensor.IsPlayerVisible) return false;
        var dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist > SafeDistance)
        {
            Move(player.transform.position);
            return true;
        }else
        {
            Stop();
            return false;
        }
    }

    public void Move(Vector3 pos)
    {
        navAgent.SetDestination(pos);
        if (navAgent.isStopped) navAgent.isStopped = false;
    }

    public void Stop()
    {
        navAgent.isStopped = true;
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
