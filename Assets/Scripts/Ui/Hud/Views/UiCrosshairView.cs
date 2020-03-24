using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCrosshairView : UiHudView
{
    protected override void InitInternal()
    {
        base.InitInternal();
        crossHair = GetComponent<Image>();
    }

    protected override void UpdateDataInternal(object[] data)
    {
        transform.position = (Vector3)data[0];
    }

    private Image crossHair;
}
