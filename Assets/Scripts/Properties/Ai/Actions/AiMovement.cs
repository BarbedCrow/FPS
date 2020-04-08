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
        var isMoving = !navAgent.velocity.Equals(Vector3.zero);
        if (visibilitySensor.IsPlayerVisible && !isMoving)
        {
            Move(player.transform.position);
            return true;
        }else if(!visibilitySensor.IsPlayerVisible && !navAgent.isStopped)
        {
            Stop();
            return false;
        }
        return isMoving;
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
