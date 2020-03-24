using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : Property
{

    [SerializeField] private float maxDiff;

    protected override void InitInternal()
    {
        base.InitInternal();

        propMovement = GetComponent<PlayerTopDownMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        var dir = propMovement.Direction;
        var hor = animator.GetFloat(HORIZONTAL);
        var vert = animator.GetFloat(VERTICAL);
        if (hor - dir.x > maxDiff)
        {
            dir.x = hor - maxDiff;
        }else if (dir.x - hor > maxDiff)
        {
            dir.x = hor + maxDiff;
        }
        if (vert - dir.z > maxDiff)
        {
            dir.z = vert - maxDiff;
        }
        else if (dir.z - vert > maxDiff)
        {
            dir.z = vert + maxDiff;
        }
        animator.SetFloat(HORIZONTAL, dir.x);
        animator.SetFloat(VERTICAL, dir.z);
    }

    private const string HORIZONTAL = "HorizontalMove";
    private const string VERTICAL = "VerticalMove";

    private PlayerTopDownMovement propMovement;
    private Animator animator;

}
