using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUiObjectView : MonoBehaviour
{
    public void Init()
    {
        InitInternal();
    }

    public void Show()
    {

    }

    public void Hide()
    {

    }

    public void UpdateData(object[] data)
    {
        UpdateDataInternal(data);
    }

    #region protected

    protected virtual void InitInternal()
    {

    }

    protected virtual void UpdateDataInternal(object[] data)
    {

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

    private string GetLogCategory()
    {
        return $"UiViews/{GetType()}:";
    }
}
