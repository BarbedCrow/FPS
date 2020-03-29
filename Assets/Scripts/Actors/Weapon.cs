using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Actor
{

    public virtual WeaponType Type { get; protected set; }

    public virtual void StartAttack()
    {
        IsAttacking = true;
    }

    public virtual void StopAttack()
    {
        IsAttacking = false;
    }

    public virtual void StartReload()
    {
        // Abstract
    }

    protected bool IsAttacking { get; private set; }

}

[System.Serializable]
public class WeaponSettings
{
    [SerializeField]
    private WeaponType type;
    public WeaponType Type { get { return type; } set { } }
}

public enum WeaponType
{
    PISTOL = 0,
    SWORD = 1,
}
