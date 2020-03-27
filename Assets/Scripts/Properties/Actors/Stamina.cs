using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : Property
{
    [SerializeField] private float basicMaxVal;
    [SerializeField] private float basicRecoverySpeed;
    [SerializeField] private float recoveryDelay;

    public float MaxVal { get; private set; }
    public float Val { get; private set; }
    public float RecoverySpeed { get; private set; }

    public bool TryGet(float val)
    {
        if (Val - val < 0) return false;

        Val -= val;
        recoveryNextTime = Time.time + recoveryDelay;
        return true;
    }

    protected override void InitInternal()
    {
        base.InitInternal();

        MaxVal = basicMaxVal;
        Val = MaxVal;
        RecoverySpeed = basicRecoverySpeed;
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        RecoveryUpdate();
    }

    private float recoveryNextTime;

    private void RecoveryUpdate()
    {
        if (Val == MaxVal) return;
        if (Time.time < recoveryNextTime) return;
        recoveryNextTime = Time.time + GlobalConsts.UPDATE_TIME_SEC;

        Val += RecoverySpeed;
        if (Val > MaxVal) Val = MaxVal;
    }

}
