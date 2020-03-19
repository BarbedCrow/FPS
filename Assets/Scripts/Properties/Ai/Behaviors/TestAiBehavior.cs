using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAiBehavior : AiBehavior
{
    protected override void ActivateInternal()
    {
        base.ActivateInternal();

        visibilitySensor = GetComponent<AiVisibilitySensor>();
        visibilitySensor.OnPlayerDetected.AddListener(ForceUpdate);
        visibilitySensor.OnPlayerLost.AddListener(ForceUpdate);
    }

    protected override void DeactivateInternal()
    {
        visibilitySensor.OnPlayerDetected.RemoveListener(ForceUpdate);
        visibilitySensor.OnPlayerLost.RemoveListener(ForceUpdate);

        base.DeactivateInternal();
    }

    protected override void UpdateInternal()
    {
        if (!IsUpdateRequired) return;

        base.UpdateInternal();
    }

    private AiVisibilitySensor visibilitySensor;

    
}
