using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Actor
{

    public WeaponType Type { get; protected set; }
    public bool CanBeStoppedByPlayer { get; protected set; }
    public bool IsAttacking { get; private set; }

    public virtual void RequestStartAttack()
    {
        if (!IsAttacking)
        {
            StartAttack();
        }
    }

    public virtual void RequestStopAttack()
    {
        if (CanBeStoppedByPlayer)
        {
            StopAttack();
        }
    }

    public virtual void StartReload()
    {
        // Abstract
    }

    protected virtual void StartAttack()
    {
        IsAttacking = true;
    }
    
    protected virtual void StopAttack()
    {
        IsAttacking = false;
    }

}

[System.Serializable]
public class WeaponSettings
{
    [SerializeField]
    private WeaponType type;
    public WeaponType Type { get { return type; } set { } }

    [SerializeField]
    private bool canBeStoppedByPlayer;
    public bool CanBeStoppedByPlayer { get { return canBeStoppedByPlayer; } set { } }
}

public enum WeaponType
{
    PISTOL = 0,
    SWORD = 1,
}
