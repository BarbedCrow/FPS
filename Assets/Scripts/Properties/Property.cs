using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{

    public bool ShouldBeActiveOnStart { get; set; } = true;

    public void Init(Actor owner)
    {
        this.owner = owner;
        CfgManager = ConfigManager.GetConfigManager();
        InitInternal();
    }

    public bool IsActive
    {
        get { return isActive; }
    }

    public void Activate()
    {
        Log($"activated by {owner.Id}");
        if (isActive)
        {
            LogWarning($"was activated twice");
            return;
        }

        isActive = true;
        ActivateInternal();
    }

    public void Deactivate()
    {
        Log($"deactivated by {owner.Id}");
        if (!isActive)
        {
            LogWarning($"was deactivated twice");
            return;
        }

        isActive = false;
        DeactivateInternal();
    }

    #region protected

    protected Actor owner;
    protected ConfigManager CfgManager { get; private set; }

    protected virtual void InitInternal()
    {

    }

    protected virtual void ActivateInternal()
    {
        
    }

    protected virtual void DeactivateInternal()
    {

    }

    protected virtual void UpdateInternal()
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

    #region private

    private bool isActive;

    private void Update()
    {
        if (IsActive)
        {
            UpdateInternal();
        }
    }

    private string GetLogCategory()
    {
        return $"Properties/{GetType()}:";
    }

    #endregion

}
