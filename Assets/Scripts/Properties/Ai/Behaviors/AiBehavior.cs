using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiBehavior : Property
{

    [SerializeField] private float updateFrequency;

    protected bool IsUpdateRequired { get; private set; }

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
        Array.Sort(actions, CompareActions);
    }

    protected override void ActivateInternal()
    {
        base.ActivateInternal();

        InvokeRepeating(LOGIC_UPDATE, updateFrequency, updateFrequency);
    }

    protected override void DeactivateInternal()
    {
        CancelInvoke(LOGIC_UPDATE);

        base.DeactivateInternal();
    }

    public int CompareActions(AiAction act1, AiAction act2)
    {
        return (act1.Priority > act2.Priority) ? 1 : 0;
    }

    private const string LOGIC_UPDATE = "LogicUpdate";

    private AiSensor[] sensors;
    private AiAction[] actions;

    private void LogicUpdate()
    {
        foreach (var action in actions)
        {
            if (action.TryToExecute()) return;
        }
    }
}
