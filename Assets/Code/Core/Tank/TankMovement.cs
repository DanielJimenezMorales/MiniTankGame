using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    #region Dependencies
    #endregion

    #region Variables
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private Transform reticleTransform = null;
    [SerializeField] private Camera camera = null;
    private float horizontalMovementInput = 0f;
    private float verticalMovementInput = 0f;
    private Rigidbody rb = null;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        horizontalMovementInput = Input.GetAxis("Horizontal");
        verticalMovementInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();
        HandleReticle();
    }

    private void MoveTank()
    {
        //Move the tank forward or backward
        Vector3 currentMovement = this.transform.forward * verticalMovementInput * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + currentMovement);
    }

    private void RotateTank()
    {
        float newRotation = horizontalMovementInput * rotationSpeed * Time.deltaTime;
        Quaternion currentRotation = this.transform.rotation * Quaternion.Euler(Vector3.up * newRotation);
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
}
