using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tankData", menuName = "ScriptableObjects/Tank")]
public class TankSO : ScriptableObject
{
    #region Dependencies
    [SerializeField] private TankMovementData movementData = null;
    #endregion

    #region Getters
    public TankMovementData GetMovementData() { return this.movementData; }
    #endregion
}