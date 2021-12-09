using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement
{
    #region Dependencies
    private TankMovementData movementData = null;
    #endregion

    #region Variables
    private Transform tankTransform = null;
    private Transform turretHeadTransform = null;
    private Transform reticleTransform = null;
    private Camera camera = null;
    private float horizontalMovementInput = 0f;
    private float verticalMovementInput = 0f;
    private Vector3 currentLookingDirection = Vector3.zero;
    private Rigidbody rb = null;
    #endregion

    public TankMovement(Rigidbody rigidBody, Transform tank, Camera cam, Transform turretHead, TankMovementData data, Transform reticle)
    {
        rb = rigidBody;
        camera = cam;
        tankTransform = tank;
        turretHeadTransform = turretHead;
        movementData = data;
        reticleTransform = reticle;
    }

    public void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        horizontalMovementInput = Input.GetAxis("Horizontal");
        verticalMovementInput = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        MoveTank();
        RotateTank();
        HandleReticle();
        HandleTurretRotation();
    }

    private void MoveTank()
    {
        //Move the tank forward or backward
        Vector3 currentMovement = tankTransform.forward * verticalMovementInput * this.movementData.GetMovementSpeed() * Time.deltaTime;
        rb.MovePosition(rb.position + currentMovement);
    }

    private void RotateTank()
    {
        float newRotation = horizontalMovementInput * this.movementData.GetRotationSpeed() * Time.deltaTime;
        Quaternion currentRotation = tankTransform.rotation * Quaternion.Euler(Vector3.up * newRotation);
        rb.MoveRotation(currentRotation);
    }

    private void HandleReticle()
    {
        Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(screenRay, out hit))
        {
            reticleTransform.position = hit.point + Vector3.up * 0.1f;
        }
    }
    
    private void HandleTurretRotation()
    {
        Vector3 desiredLookingDirection = reticleTransform.position - turretHeadTransform.position;
        desiredLookingDirection.y = 0f;
        desiredLookingDirection = desiredLookingDirection.normalized;
        currentLookingDirection = currentLookingDirection.normalized;

        currentLookingDirection = Vector3.Lerp(currentLookingDirection, desiredLookingDirection, Time.deltaTime * this.movementData.GetTurretHeadRotationSpeed());

        turretHeadTransform.rotation = Quaternion.LookRotation(currentLookingDirection);
    }
}