using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCrosshairController : UiHudController
{

    protected override void InitInternal()
    {
        base.InitInternal();

        playerCamera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<Camera>();
    }

    protected override object[] CreateData()
    {
        var data = new object[] { Input.mousePosition };
        return data;
    }

    private Camera playerCamera;

    private void Update()
    {
        if (!IsVisible) return;

        UpdateData();
    }
}
