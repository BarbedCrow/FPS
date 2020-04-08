using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiRotation : AiAction
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float angleTolerance;
    [SerializeField] private float maxRotationDistance;

    protected override bool TryToExecuteInternal()
    {
        if (isRotating) return false;
        if (Vector3.Distance(transform.position, player.transform.position) > maxRotationDistance) return false;
        var dir = player.transform.position - transform.position;
        var angle = Vector3.Angle(transform.forward, dir);
        if (angle < angleTolerance) return false;

        rotateDir = new Vector3(dir.x, 0, dir.z);
        isRotating = true;

        return true;
    }

    protected override void InitInternal()
    {
        base.InitInternal();

        visibilitySensor = GetComponent<AiVisibilitySensor>();
        navAgent = GetComponent<NavMeshAgent>();
        player = GameMaster.GetGameMaster().Player;
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();
        if (!isRotating) return;
        var angle = Vector3.Angle(transform.forward, rotateDir);
        if (angle < angleTolerance)
        {
            isRotating = false;
            return;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDir), Time.deltaTime * rotationSpeed);
    }

    private AiVisibilitySensor visibilitySensor;
    private NavMeshAgent navAgent;
    private Player player;
    private Vector3 rotateDir;
    private bool isRotating;
}
