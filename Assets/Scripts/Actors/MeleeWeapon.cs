using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    [SerializeField] private MeleeWeaponSettings settings;

    public MeleeWeaponSettings Settings { get { return settings; } set { } }

    protected override void InitInternal()
    {
        base.InitInternal();

        Type = settings.Type;
    }

}

[System.Serializable]
public class MeleeWeaponSettings : WeaponSettings
{
    
}
