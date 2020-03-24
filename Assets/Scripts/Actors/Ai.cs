using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : Actor
{

    protected override void InitInternal()
    {
        base.InitInternal();

        bhvController = GetComponent<AiBehavior>();
        bhvController.Init(this);
    }

    private AiBehavior bhvController;

}
