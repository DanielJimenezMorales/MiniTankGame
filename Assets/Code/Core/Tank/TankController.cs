using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class TankController : MonoBehaviour
{
    #region Dependencies
    [SerializeField] private TankSO tankData = null;
    private TankMovement movement = null;
    #endregion

    #region Variables
    [Header("Movement properties:")]
    [SerializeField] private Transform turretHeadTransform = null;
    [SerializeField] private Transform reticleTransform = null;
    [SerializeField] private Camera tankCamera = null;
    private Rigidbody rb = null;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "TankController at Awake: The rigidBody component is null");

        movement = new TankMovement(rb, this.transform, tankCamera, turretHeadTransform, tankData.GetMovementData(), reticleTransform);
    }

    private void Update()
    {
        movement.Update();
    }

    private void FixedUpdate()
    {
        movement.FixedUpdate();
    }
}