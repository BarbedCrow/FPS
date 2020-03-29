using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUser : Property
{

    public Weapon CurrentWeapon { get; private set; }

    public bool SwapToFirearm(int idx)
    {
        Log($"{owner.Id} swap firearm to {idx}");
        if(idx == currWeaponIdx)
        {
            if (CurrentWeapon.IsActive)
            {
                Log("Trying to swap to the same firearm");
            }
            else
            {
                Log("current firearm was reactivated");
                CurrentWeapon.Activate(owner);
            }
            return false;
        }
        CurrentWeapon?.Deactivate(owner);
        if (weapons.Length == 0)
        {
            LogWarning($"list is empty");
            return false;
        }
        if (idx >= weapons.Length)
        {
            LogWarning($"idx of new firearm is bigger than weapons count({weapons.Length})");
            return false;
        }

        CurrentWeapon = weapons[idx];
        CurrentWeapon.Activate(owner);
        return true;
    }

    public void RequestStartFire()
    {
        CurrentWeapon?.StartAttack();
    }

    public void RequestStopFire()
    {
        CurrentWeapon?.StopAttack();
    }

    public void RequestReload()
    {
        CurrentWeapon?.StartReload();
    }

    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();

        weapons = gameObject.GetComponentsInChildren<Weapon>();
        
        foreach(Weapon weapon in weapons)
        {
            weapon.Init(owner);
        }
    }

    protected override void ActivateInternal()
    {
        base.ActivateInternal();

        if(CurrentWeapon == null)
        {
            SwapToFirearm(DEFAULT_FIREARM_IDX);
        }
    }

    #endregion

    #region private

    private const int DEFAULT_FIREARM_IDX = 0;

    private Weapon[] weapons;

    private int currWeaponIdx = -1;

    #endregion

}
