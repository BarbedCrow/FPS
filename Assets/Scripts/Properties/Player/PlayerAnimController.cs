using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : Property
{

    [SerializeField] private float maxDiff;

    protected override void InitInternal()
    {
        base.InitInternal();

        propMovement = GetComponent<PlayerTopDownMovement>();
        animator = GetComponentInChildren<Animator>();
        weaponUser = GetComponent<WeaponUser>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();
        if(currWeaponType != weaponUser.CurrentWeapon.Type)
        {
            currWeaponType = weaponUser.CurrentWeapon.Type;
            Log($"Weapon type{currWeaponType}");
            animator.SetInteger(WEAPON_TYPE, (int)weaponUser.CurrentWeapon.Type); // change weapon type animations
        }

        //movement animations
        var dir = propMovement.Direction;
        var hor = animator.GetFloat(HORIZONTAL);
        var vert = animator.GetFloat(VERTICAL);
        if (hor - dir.x > maxDiff)
        {
            dir.x = hor - maxDiff;
        }else if (dir.x - hor > maxDiff)
        {
            dir.x = hor + maxDiff;
        }
        if (vert - dir.z > maxDiff)
        {
            dir.z = vert - maxDiff;
        }
        else if (dir.z - vert > maxDiff)
        {
            dir.z = vert + maxDiff;
        }
        animator.SetFloat(HORIZONTAL, dir.x);
        animator.SetFloat(VERTICAL, dir.z);
    }

    private const string WEAPON_TYPE = "WeaponType";
    private const string HORIZONTAL = "HorizontalMove";
    private const string VERTICAL = "VerticalMove";

    private PlayerTopDownMovement propMovement;
    private WeaponUser weaponUser;
    private Animator animator;
    private WeaponType currWeaponType;

}
