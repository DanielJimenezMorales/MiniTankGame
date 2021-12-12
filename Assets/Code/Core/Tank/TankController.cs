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
    private TankShoot shoot = null;
    #endregion

    #region Variables
    [Header("Movement properties:")]
    [SerializeField] private Transform turretHeadTransform = null;
    [SerializeField] private Transform reticleTransform = null;
    [SerializeField] private Transform shootPointTransform = null;
    [SerializeField] private AudioConsumer firingAudioConsumer = null;
    [SerializeField] private Camera tankCamera = null;
    [SerializeField] private GameObject explosionPrefab = null;
    [SerializeField] private GameObject tankExplosion = null;
    private Rigidbody rb = null;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb, "TankController at Awake: The rigidBody component is null");
    }

    private void Start()
    {
        movement = new TankMovement(rb, this.transform, tankCamera, turretHeadTransform, tankData.GetMovementData(), reticleTransform);
        shoot = new TankShoot(shootPointTransform, tankData.GetSoundsData(), firingAudioConsumer, explosionPrefab, tankExplosion);
    }

    private void Update()
    {
        movement.Update();
        shoot.Update();
    }

    private void FixedUpdate()
    {
        movement.FixedUpdate();
    }
}