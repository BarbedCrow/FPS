using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : Property
{
    protected override void InitInternal()
    {
        base.InitInternal();

        //cam = GetComponentInChildren<Camera>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        //cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, 0, 0);
    }

    private Camera cam;
    private Quaternion initRotation;
}
