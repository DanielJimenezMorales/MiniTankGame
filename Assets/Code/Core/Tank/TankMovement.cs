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
    private Rigidbody rb = null;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            MoveTank(1);
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {
            MoveTank(-1);
        }
    }

    private void MoveTank(int direction)
    {
        Vector3 force = this.transform.forward * direction * movementSpeed;
        rb.AddForce(force, ForceMode.Acceleration);
    }
}
