using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    [SerializeField] private MeleeWeaponSettings settings;

    public MeleeWeaponSettings Settings { get { return settings; } set { } }

    protected override void StopAttack()
    {
        damagedObjects.Clear();

        base.StopAttack();
    }

    protected override void StartAttack()
    {
        base.StartAttack();

        stopAttackTime = Time.time + settings.AttackTime;
    }

    protected override void InitInternal()
    {
        base.InitInternal();

        Type = settings.Type;
        CanBeStoppedByPlayer = settings.CanBeStoppedByPlayer;
    }

    protected override void Update()
    {
        base.Update();

        if (!IsAttacking) return;
        if (Time.time < stopAttackTime) return;

        StopAttack();
    }

    private float stopAttackTime;
    private List<GameObject> damagedObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!IsAttacking) return;
        if (damagedObjects.Contains(other.gameObject)) return;
        var damagable = other.gameObject.GetComponentInParent<Damagable>();
        if (damagable == null) return;
        damagedObjects.Add(other.gameObject);
        var info = new DamageInfo();
        info.damager = owner;
        info.hitPoint = other.gameObject.transform.position;
        info.damage = settings.Damage;
        damagable.DoDamage(info);
    }

}

[System.Serializable]
public class MeleeWeaponSettings : WeaponSettings
{
    [SerializeField] private float attackTime;
    public float AttackTime { get { return attackTime; } set { } }

    [SerializeField] private int damage;
    public int Damage { get { return damage; } set { } }
}
