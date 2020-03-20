using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAiBehavior : AiBehavior
{
    protected override void ActivateInternal()
    {
        base.ActivateInternal();

        visibilitySensor = GetComponent<AiVisibilitySensor>();
        movement = GetComponent<AiMovement>();

        //visibilitySensor.OnPlayerDetected.AddListener(ForceUpdate);
        //visibilitySensor.OnPlayerLost.AddListener(ForceUpdate);
    }

    protected override void DeactivateInternal()
    {
        //visibilitySensor.OnPlayerDetected.RemoveListener(ForceUpdate);
        //visibilitySensor.OnPlayerLost.RemoveListener(ForceUpdate);

        base.DeactivateInternal();
    }

    protected override void UpdateInternal()
    {
        if (visibilitySensor.IsPlayerVisible)
        {
            var dist = Vector3.Distance(transform.position, Player.transform.position);
            if(dist > SafeDistance)
            {
                movement.Move(Player.transform.position);
            }
            else
            {
                movement.Stop();
            }
            
        }

        base.UpdateInternal();
    }

    private AiVisibilitySensor visibilitySensor;

    private AiMovement movement;

}
