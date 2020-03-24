using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public void Init(Actor owner)
    {
        this.owner = owner;
        InitInternal();
    }

    public bool IsActive
    {
        get { return isActive; }
    }

    public void Activate(Actor host)
    {
        if(host != owner)
        {
            LogError($"is trying to be activated by {host.Id}, but owner is {owner.Id}");
            return;
        }
        Log($"activated by {host.Id}");
        if (isActive)
        {
            LogWarning($"was activated twice");
            return;
        }

        isActive = true;
        ActivateInternal();
    }

    public void Deactivate(Actor host)
    {
        if (host != owner)
        {
            LogError($"is trying to be activated by {host.Id}, but owner is {owner.Id}");
            return;
        }
        Log($"deactivated by {host.Id}");
        if (!isActive)
        {
            LogWarning($"was deactivated twice");
            return;
        }

        isActive = false;
        DeactivateInternal();
    }

    public string Id { get { return $"{GetType()}{GetInstanceID().ToString()}"; } set { } }

    #region protected

    protected Property[] properties;
    protected Actor owner;

    protected virtual void InitInternal()
    {
        properties = GetComponents<Property>();
        foreach (Property property in properties)
        {
            if (property.ShouldBeActiveOnStart)
            {
                property.Init(this);
                property.Activate();
            }
        }
    }

    protected virtual void ActivateInternal()
    {

    }

    protected virtual void DeactivateInternal()
    {

    }

    protected virtual void OnDestroy()
    {

    }

    protected virtual void Update()
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

    private string GetLogCategory()
    {
        return $"Actors/{GetType()}:";
    }

    #endregion
}

[System.Serializable]
public class ActorDesc
{
    [SerializeField]
    private Actor actor;

    [SerializeField]
    private Transform spawnPoint;

    public Actor Actor { get { return actor; } set { } }
    public Transform SpawnPoint { get { return spawnPoint; } set { } }
}
