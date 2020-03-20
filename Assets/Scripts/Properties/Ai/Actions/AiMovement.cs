using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : AiAction
{

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

        navAgent = GetComponent<NavMeshAgent>();
    }

    private NavMeshAgent navAgent;

}
