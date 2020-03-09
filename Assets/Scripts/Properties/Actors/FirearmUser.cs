using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmUser : Property
{

    public bool SwapToFirearm(int idx)
    {
        Log($"{owner.Id} swap firearm to {idx}");
        if(idx == currFirearmIdx)
        {
            if (currFirearm.IsActive)
            {
                Log("Trying to swap to the same firearm");
            }
            else
            {
                Log("current firearm was reactivated");
                currFirearm.Activate(owner);
            }
        }
        currFirearm?.Deactivate(owner);
        if (firearms.Length == 0)
        {
            LogWarning($"list is empty");
            return false;
        }
        if (idx >= firearms.Length)
        {
            LogWarning($"idx of new firearm is bigger than firearms count({firearms.Length})");
            return false;
        }

        currFirearm = firearms[idx];
        currFirearm.Activate(owner);
        return true;
    }

    public void RequestStartFire()
    {
        currFirearm?.TryStartFire();
    }

    public void RequestStopFire()
    {
        currFirearm?.StopFire();
    }

    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();

        firearms = gameObject.GetComponentsInChildren<Firearm>();
        
        foreach(Firearm firearm in firearms)
        {
            firearm.Init(owner);
        }
    }

    protected override void ActivateInternal()
    {
        base.ActivateInternal();

        if(currFirearm == null)
        {
            SwapToFirearm(DEFAULT_FIREARM_IDX);
        }
    }

    #endregion

    #region private

    private const int DEFAULT_FIREARM_IDX = 0;

    private Firearm[] firearms;
    private Firearm currFirearm;

    private int currFirearmIdx = -1;

    #endregion

}
