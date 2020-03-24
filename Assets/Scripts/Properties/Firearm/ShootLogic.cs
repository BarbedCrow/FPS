using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : Property
{
    public virtual void Fire()
    {

    }

    public void SetInitialParams(Transform [] startTransforms, Vector2 groupRadius, float range, float bulletSpeed, int damage, Actor firearmOwner)
    {
        this.startTransforms = startTransforms;
        this.groupRadius = groupRadius;
        this.range = range;
        this.bulletSpeed = bulletSpeed;
        this.damage = damage;
        this.firearmOwner = firearmOwner;
    }

    protected Transform [] startTransforms;
    protected Vector2 groupRadius;
    protected float range;
    protected float bulletSpeed;
    protected int damage;
    protected Actor firearmOwner;
}
