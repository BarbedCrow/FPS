using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseUiObjectController : MonoBehaviour
{
    
    public bool IsVisible { get; private set; }

    public void Init()
    {
        InitInternal();
        View = gameObject.GetComponent<BaseUiObjectView>();
        View.Init();
    }

    public void Show()
    {
        IsVisible = true;
        View.Show();
        ShowInternal();
    }

    public void Hide()
    {
        IsVisible = false;
        View.Hide();
        HideInternal();
    }

    public void UpdateData()
    {
        View.UpdateData(CreateData());
    }

    #region protected

    protected BaseUiObjectView View { get; private set; }

    protected virtual void InitInternal()
    {

    }

    protected virtual void ShowInternal()
    {

    }

    protected virtual void HideInternal()
    {

    }

    protected virtual object[] CreateData()
    {
        return new object[0];
    }

    protected void Log(string msg)
    {
        Debug.Log($"{GetLogCategory()} {msg}");
    }

    protected void LogWarning(string msg)
    {
        Debug.LogWarning($"{GetLogCategory()} {msg}");
    }

    protected void LogError(string msg)
    {
        Debug.LogError($"{GetLogCategory()} {msg}");
    }

    #endregion

    #region private

    private string GetLogCategory()
    {
        return $"UiControllers/{GetType()}:";
    }

    #endregion

}
