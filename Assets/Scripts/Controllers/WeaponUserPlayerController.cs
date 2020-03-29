using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponUserPlayerController : Property
{

    #region protected

    protected override void InitInternal()
    {
        base.InitInternal();

        weaponUser = GetComponent<WeaponUser>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        SlotSelectorUpdate();

        if (CrossPlatformInputManager.GetButtonDown(ActionNames.FIRE))
        {
            weaponUser.RequestStartFire();
        }else if (CrossPlatformInputManager.GetButtonUp(ActionNames.FIRE))
        {
            weaponUser.RequestStopFire();
        }else if(CrossPlatformInputManager.GetButtonDown(ActionNames.RELOAD))
        {
            weaponUser.RequestReload();
        }
    }

    #endregion

    #region private

    private WeaponUser weaponUser;

    private void SlotSelectorUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponUser.SwapToFirearm(0);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponUser.SwapToFirearm(1);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponUser.SwapToFirearm(2);
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponUser.SwapToFirearm(3);
        }else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponUser.SwapToFirearm(4);
        }else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            weaponUser.SwapToFirearm(5);
        }else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            weaponUser.SwapToFirearm(6);
        }else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            weaponUser.SwapToFirearm(7);
        }else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            weaponUser.SwapToFirearm(8);
        }else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            weaponUser.SwapToFirearm(9);
        }
    }

    #endregion

}
