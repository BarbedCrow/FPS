using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public void Activate(float range, float speed, int damage, Actor owner, Transform spawn)
    {
        this.range = range;
        this.speed = speed;
        this.damage = damage;
        this.firearmOwner = owner;
        transform.position = spawn.position;
        startPos = transform.position;
    }

    private float speed;
    private float range;
    private int damage;
    private Actor firearmOwner;

    private Vector3 startPos;

    private void Update()
    {
        var dir = transform.forward * speed * Time.deltaTime;
        transform.position = transform.position + dir;
        if (Vector3.Distance(startPos, transform.position) > range) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damagable = other.gameObject.GetComponent<Damagable>();
        if (damagable != null)
        {
            var damageInfo = new DamageInfo();
            damageInfo.hitPoint = transform.position;
            damageInfo.damager = firearmOwner;
            damageInfo.damage = damage;
            damagable.DoDamage(damageInfo);
        }
        Destroy(gameObject);
    }
}
