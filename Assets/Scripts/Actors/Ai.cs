using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : Actor
{

    protected override void Start()
    {
        base.Start();

        bhvController = GetComponent<AiBehavior>();
        bhvController.Init(this);
    }

    private AiBehavior bhvController;

}
