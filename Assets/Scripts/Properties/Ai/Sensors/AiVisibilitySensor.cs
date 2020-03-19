using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiVisibilitySensor : AiSensor
{
    [HideInInspector] public UnityEvent OnPlayerDetected = new UnityEvent();
    [HideInInspector] public UnityEvent OnPlayerLost = new UnityEvent();

    [SerializeField] private float scanLength;
    [SerializeField] private float scanHeight;//will be implemented later
    [SerializeField] [Tooltip("degrees")] private float scanWidth;

    public bool IsPlayerVisible { get; private set; }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        if(CfgManager.DbgDrawConfig.drawDebugVisualScanners) DbgDraw(); // debug draw

        //Check distance to player
        var playerTransform = Player.transform;
        var playerPos = new Vector2(playerTransform.position.x, playerTransform.position.z);
        var scannerPos = new Vector2(transform.position.x, transform.position.z);
        var forward2d = new Vector2(transform.forward.x, transform.forward.z);
        var dist = Vector3.Distance(playerPos, scannerPos);
        if (dist > scanLength)
        {
            if (IsPlayerVisible)
            {
                IsPlayerVisible = false;
                OnPlayerLost.Invoke();
            }
            return;
        }

        //Check angle
        var dir = playerPos - scannerPos;
        var angle = Vector2.Angle(forward2d, dir);
        if (angle > scanWidth / 2)
        {
            if (IsPlayerVisible)
            {
                IsPlayerVisible = false;
                OnPlayerLost.Invoke();
            }
            return;
        }

        if (!IsPlayerVisible)
        {
            IsPlayerVisible = true;
            OnPlayerDetected.Invoke();
        }
    }

    private void DbgDraw()
    {
        var pos = transform.forward * scanLength;
        var posPos = Quaternion.AngleAxis(scanWidth / 2, transform.up) * pos;
        var negPos = Quaternion.AngleAxis(-scanWidth / 2, transform.up) * pos;
        var color = IsPlayerVisible ? Color.red : Color.green;
        Debug.DrawRay(transform.position, posPos, color);
        Debug.DrawRay(transform.position, negPos, color);
    }
}
