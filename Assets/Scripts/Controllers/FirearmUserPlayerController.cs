using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FirearmUserPlayerController : Property
{

    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();

        firearmUser = GetComponent<FirearmUser>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        if (CrossPlatformInputManager.GetButtonDown(ActionNames.FIRE))
        {
            firearmUser.RequestStartFire();
        }else if (CrossPlatformInputManager.GetButtonUp(ActionNames.FIRE))
        {
            firearmUser.RequestStopFire();
        }
    }

    #endregion

    #region private

    private FirearmUser firearmUser;

    #endregion

}
