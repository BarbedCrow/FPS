using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHudController : BaseUiObjectController
{

    #region protected

    protected GameMaster gameMaster;

    protected override void InitInternal()
    {
        base.InitInternal();

        gameMaster = GameMaster.GetGameMaster();
    }

    #endregion

}
