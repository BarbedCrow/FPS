using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHudBulletsCounterController : UiHudController
{

    protected override void InitInternal()
    {
        base.InitInternal();

        firearmUser = gameMaster.Player.GetComponent<FirearmUser>();
    }

    protected override object[] CreateData()
    {
        var data = base.CreateData();
        if (firearmUser.CurrentFirearm != null)
        {
            var bulletsInClip = firearmUser.CurrentFirearm.CurrBulletsInClip.ToString();
            var bulletsCount = firearmUser.CurrentFirearm.CurrBulletsCount.ToString();
            var text = $"Bullets:{bulletsInClip} / {bulletsCount}";
            data = new object[] { text };
        }
        return data;
    }

    #region private

    private FirearmUser firearmUser;

    private void Update()
    {
        if (!IsVisible) return;

        UpdateData();
    }

    #endregion

}
