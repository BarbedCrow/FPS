using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : Property
{

    [SerializeField] private int maxHp;

    [HideInInspector] public UnityEvent OnDie = new UnityEvent();

    public int Hp { get; private set; }
    public int MaxHp { get { return maxHp; } set { } }

    public void DoDamage(DamageInfo info)
    {
        Hp -= info.damage;
        if (Hp <= 0) Die();
    }

    protected override void InitInternal()
    {
        base.InitInternal();

        Hp = maxHp;
    }

    private void Die()
    {
        OnDie.Invoke();
        Destroy(gameObject);
    }

}

public class DamageInfo
{
    public Vector3 hitPoint;
    public Actor damager;
    public int damage;
}
