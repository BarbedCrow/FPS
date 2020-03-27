using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiStaminaController : UiHudController
{
    protected override void InitInternal()
    {
        base.InitInternal();

        stamina = gameMaster.Player.GetComponent<Stamina>();
    }

    protected override object[] CreateData()
    {
        var data = base.CreateData();
        var maxVal = stamina.MaxVal.ToString();
        var val = stamina.Val.ToString();
        var text = $"Stamina:{val} / {maxVal}";
        data = new object[] { text };
        return data;
    }

    #region private

    private Stamina stamina;

    private void Update()
    {
        if (!IsVisible) return;

        UpdateData();
    }

    #endregion
}
