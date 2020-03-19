using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSensor : Property
{

    protected Player Player { get; private set; }

    protected override void InitInternal()
    {
        base.InitInternal();

        Player = GameMaster.GetGameMaster().Player;
    }
}
