using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TopDownCameraFollow : MonoBehaviour
{
    #region Variables
    [SerializeField] private float distance = 5f; //distance from the player in the Z axis (backwards)
    [SerializeField] private float initialAngle = 43f;
    [SerializeField] private float cameraRotationSpeed = 1.5f;
    [SerializeField] private float height = 9.5f;
    [SerializeField] private float smoothness = 0.6f;
    private float currentAngle = 0f;
    private Vector3 referenceVelocity = Vector3.zero;
    private Vector3 cameraWorldPosition = Vector3.zero;
    private Vector3 angleVector = Vector3.zero;

    private Transform targetTransform = null;
    #endregion

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentAngle = initialAngle;
        cameraWorldPosition = (height * Vector3.up) + (-1 * distance * Vector3.forward);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentAngle += cameraRotationSpeed * Input.GetAxis("Mouse X");
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Assert.IsNotNull(targetTransform, "TopDownCameraFollow at FollowTarget: The target transform is null");

        Vector3 angleVector = Quaternion.AngleAxis(currentAngle, Vector3.up) * cameraWorldPosition;
        Vector3 finalPosition = targetTransform.position + angleVector;

        this.transform.position = Vector3.SmoothDamp(this.transform.position, finalPosition, ref referenceVelocity, smoothness);
        this.transform.LookAt(targetTransform);
    }
}
