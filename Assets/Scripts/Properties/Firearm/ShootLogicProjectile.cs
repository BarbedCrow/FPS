using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogicProjectile : ShootLogic
{
    [SerializeField] private Projectile projectileDesc;

    public override void Fire()
    {
        foreach(var spawn in startTransforms)
        {
            var projectile = Instantiate(projectileDesc, spawn.position, spawn.rotation) as Projectile;
            projectile.Activate(range, bulletSpeed, damage, firearmOwner, spawn);
        }
    }
}
