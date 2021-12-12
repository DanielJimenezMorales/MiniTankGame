using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankSoundsData
{
    #region Variables
    [SerializeField] private AudioClip firingSound = null;
    #endregion

    #region Getters
    public AudioClip GetFiringSound() { return this.firingSound; }
    #endregion
}
