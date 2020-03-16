using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{

    public void Init()
    {
        var canvas = GameObject.FindGameObjectWithTag(Tags.CANVAS);
        controllers = canvas.GetComponentsInChildren<UiHudController>();
        foreach(var ctrl in controllers)
        {
            ctrl.Init();
        }
    }

    public void Enable()
    {
        foreach (var ctrl in controllers)
        {
            ctrl.Show();
        }
    }

    public void Disable()
    {
        foreach (var ctrl in controllers)
        {
            ctrl.Hide();
        }
    }

    public void Terminate()
    {

    }

    #region private

    private UiHudController[] controllers;

    #endregion

}
