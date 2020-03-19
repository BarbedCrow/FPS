using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehavior : Property
{

    protected bool IsUpdateRequired { get; private set; }

    protected override void InitInternal()
    {
        base.InitInternal();

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

        IsUpdateRequired = false;
    }

    protected virtual void ForceUpdate()
    {
        IsUpdateRequired = true;
    }

    private AiSensor[] sensors;
    private AiAction[] actions;

}
