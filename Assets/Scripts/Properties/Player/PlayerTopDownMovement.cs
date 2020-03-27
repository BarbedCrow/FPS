using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerTopDownMovement : Property
{

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float runStaminaCost;

    public float Speed { get; private set; }
    public float IsMoving { get; private set; }
    public Vector3 Direction { get; private set; }

    protected override void InitInternal()
    {
        base.InitInternal();

        playerCamera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA).GetComponent<Camera>();
        body = GetComponentInChildren<Rigidbody>();
        Speed = walkSpeed;
        stamina = GetComponent<Stamina>();
    }

    protected override void UpdateInternal()
    {
        base.UpdateInternal();

        body.velocity = new Vector3(0, body.velocity.y, 0); // to prevent physical influence
        UpdateMovement();
        UpdateRotation();
        UpdateSprint();
    }

    private Rigidbody body;
    private Camera playerCamera;
    private Stamina stamina;
    private bool isSprinting;
    private float nextStaminaTakeTime;

    private void UpdateSprint()
    {
        if (CrossPlatformInputManager.GetButtonDown(ActionNames.SPRINT))
        {
            StartSprint();
        }else if (CrossPlatformInputManager.GetButtonUp(ActionNames.SPRINT) && isSprinting)
        {
            StopSprint();
        }

        if (!isSprinting) return;
        if (Time.time < nextStaminaTakeTime) return;
        nextStaminaTakeTime = Time.time + GlobalConsts.UPDATE_TIME_SEC;
        if (!stamina.TryGet(runStaminaCost)) StopSprint();
    }

    private void StartSprint()
    {
        isSprinting = true;
        Speed = runSpeed;
        nextStaminaTakeTime = Time.deltaTime;
    }

    private void StopSprint()
    {
        Speed = walkSpeed;
        isSprinting = false;
    }

    private void UpdateMovement()
    {
        float moveX = Input.GetAxis(ActionNames.VERTICAL_MOVE);
        float moveZ = Input.GetAxis(ActionNames.HORIZONTAL_MOVE);
        Direction = (transform.forward * moveX + transform.right * moveZ);
        //Log($"Direction{Direction}");
        var velocity = (Vector3.forward * moveX + Vector3.right * moveZ) * Speed;
        // Clamp is used to prevent getting higher velocity when character moves diagonally
        velocity = Vector3.ClampMagnitude(velocity, Speed * Time.deltaTime);
        body.MovePosition(body.position + velocity);
    }

    private void UpdateRotation()
    {
        var ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit)) return;
        transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
    }

    private void OnDrawGizmos() // Debug draw
    {
        var ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit, (int)PhysicLayers.FLOOR))
        {
            return;
        }
        
        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireCube(hit.point, new Vector3(1, 1, 1));
        UnityEditor.Handles.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
