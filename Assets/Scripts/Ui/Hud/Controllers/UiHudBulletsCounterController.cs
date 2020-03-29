using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHudBulletsCounterController : UiHudController
{

    protected override void InitInternal()
    {
        base.InitInternal();

        weaponUser = gameMaster.Player.GetComponent<WeaponUser>();
    }

    protected override object[] CreateData()
    {
        var data = base.CreateData();
        var firearm = weaponUser.CurrentWeapon as Firearm;
        if (firearm != null)
        {
            var bulletsInClip = firearm.CurrBulletsInClip.ToString();
            var bulletsCount = firearm.CurrBulletsCount.ToString();
            var text = $"Bullets:{bulletsInClip} / {bulletsCount}";
            data = new object[] { text };
        }else
        {
            data = new object[] { "Melee weapon" };
        }
        return data;
    }

    #region private

    private WeaponUser weaponUser;

    private void Update()
    {
        if (!IsVisible) return;

        UpdateData();
    }

    #endregion

}
