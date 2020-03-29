using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealthBarController : UiHudController
{
    protected override void InitInternal()
    {
        base.InitInternal();

        damagable = gameMaster.Player.GetComponentInParent<Damagable>();
    }

    protected override object[] CreateData()
    {
        var data = base.CreateData();
        var maxHp = damagable.MaxHp.ToString();
        var hp = damagable.Hp.ToString();
        var text = $"Health:{hp} / {maxHp}";
        data = new object[] { text };
        return data;
    }

    #region private

    private Damagable damagable;

    private void Update()
    {
        if (!IsVisible) return;

        UpdateData();
    }

    #endregion
}
