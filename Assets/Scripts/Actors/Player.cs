using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();

        cam = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<GameCamera>();
        cam.Init(this);
        cam.Activate(this);
    }

    protected override void Update()
    {
        base.Update();
    }

    #endregion

    private GameCamera cam;
}
