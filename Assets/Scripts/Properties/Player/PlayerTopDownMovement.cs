using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopDownMovement : Property
{

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public float Speed { get; private set; }
    public float IsMoving { get; private set; }

    protected override void InitInternal()
    {
        base.InitInternal();

        playerCamera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<Camera>();
        body = GetComponentInChildren<Rigidbody>();
        Speed = walkSpeed;
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        body.velocity = Vector3.zero; // to prevent physical influence
        UpdateMovement();
        UpdateRotation();
    }

    private Rigidbody body;
    private Camera playerCamera;

    private void UpdateMovement()
    {
        float moveX = Input.GetAxis(ActionNames.VERTICAL_MOVE);
        float moveZ = Input.GetAxis(ActionNames.HORIZONTAL_MOVE);
        var velocity = (Vector3.forward * moveX + Vector3.right * moveZ) * Speed * Time.deltaTime;
        body.MovePosition(body.position + velocity);
    }

    private void UpdateRotation()
    {
        var ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }
        var dir = hit.point - transform.position;
        var angle = Vector3.Angle(transform.forward, dir);
        if (angle < 0.1) return;
        transform.Rotate(transform.up, angle);
        Log($"angle:{angle}");
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    private void OnDrawGizmos() // Debug draw
    {
        var ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit))
        {
            return;
        }
        
        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireCube(hit.point, new Vector3(1, 1, 1));
        UnityEditor.Handles.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
