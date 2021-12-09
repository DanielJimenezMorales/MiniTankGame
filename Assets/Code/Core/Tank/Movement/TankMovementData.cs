using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankMovementData
{
    #region Variables
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float turretHeadRotationSpeed = 5f;
    #endregion

    public TankMovementData() { }

    #region Getters
    public float GetMovementSpeed() { return this.movementSpeed; }
    public float GetRotationSpeed() { return this.rotationSpeed; }
    public float GetTurretHeadRotationSpeed() { return this.turretHeadRotationSpeed; }
    #endregion
}