using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBarView : UiHudView
{
    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();
        textField = GetComponent<Text>();
    }

    protected override void UpdateDataInternal(object[] data)
    {
        textField.text = (string)data[0];
    }

    #endregion

    #region private

    private Text textField;

    #endregion
}
