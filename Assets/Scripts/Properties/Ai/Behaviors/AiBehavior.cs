using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehavior : Property
{

    [SerializeField] private float safeDistance;

    protected bool IsUpdateRequired { get; private set; }

    protected float SafeDistance { get { return safeDistance; } private set { } }

    protected Player Player { get; private set; }

    protected override void InitInternal()
    {
        base.InitInternal();

        Player = GameMaster.GetGameMaster().Player;

        sensors = GetComponentsInChildren<AiSensor>();
        actions = GetComponentsInChildren<AiAction>();
        foreach(var sensor in sensors)
        {
            sensor.Init(owner);
        }
        foreach (var action in actions)
        {
            action.Init(owner);
        }
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        //IsUpdateRequired = false;
    }

    protected virtual void ForceUpdate()
    {
        IsUpdateRequired = true;
    }

    private AiSensor[] sensors;
    private AiAction[] actions;

}
