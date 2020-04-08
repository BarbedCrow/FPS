using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAction : Property
{
    [SerializeField] private float priority;
    [SerializeField] private float minTimeBetweenExecution;
    [SerializeField] private float maxTimeBetweenExecution;

    [SerializeField] public float Priority { get { return priority; } private set { } }

    public bool TryToExecute()
    {
        if (Time.time < timeForNextExecution) return false;
        if (!TryToExecuteInternal()) return false;
        HandleExecution();
        return true;
    }

    protected virtual bool TryToExecuteInternal()
    {
        return true;
    }

    protected void HandleExecution()
    {
        timeForNextExecution = Time.time + Random.Range(minTimeBetweenExecution, maxTimeBetweenExecution);
    }

    private float timeForNextExecution;
}
