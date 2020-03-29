using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogicRaycast : ShootLogic
{

    public override void Fire()
    {
        //Hit detection
        var pos = startTransforms[0].position;

        //calculate destination point https://stackoverflow.com/a/50746409/276052
        var radius = Random.Range(groupRadius.x, groupRadius.y); // TO DO: radius dependency of fire rate
        var r = radius * Mathf.Sqrt(Random.Range(0, 1f));
        var theta = Random.Range(0, 1f) * 2 * Mathf.PI;
        var x = r * Mathf.Cos(theta);
        var y = r * Mathf.Sin(theta);
        var endPos = startTransforms[0].forward * range + startTransforms[0].right * x + startTransforms[0].up * y;

        //Try to find damagable entity and do damage
        //For now it works only for one bullet at time guns,
        //but at the end should work also for multiple bullets at time
        RaycastHit hitInfo;
        Physics.Raycast(pos, endPos, out hitInfo, range);
        var damagable = hitInfo.transform?.GetComponentInParent<Damagable>();
        if (damagable != null)
        {
            var damageInfo = new DamageInfo();
            damageInfo.hitPoint= hitInfo.point;
            damageInfo.damager = owner;
            damageInfo.damage = damage;
            damagable.DoDamage(damageInfo);
        }
        Debug.DrawRay(pos, endPos, Color.red, 1);
    }
    
    private void OnDrawGizmos() // Debug draw
    {
        var pos = startTransforms[0].position;
        UnityEditor.Handles.color = Color.green;
        var endPos = pos + startTransforms[0].forward * range;
        UnityEditor.Handles.DrawWireDisc(endPos, startTransforms[0].forward, groupRadius.y);
    }

}
