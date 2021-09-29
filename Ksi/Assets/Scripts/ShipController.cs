using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Ship Settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    // local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    //Components
    Rigidbody2D shipRigidbody2D;

    private void Awake()
    {
        shipRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //create a force to the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //apply force and pushes the ship foward
        shipRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }
    private void ApplySteering()
    {
        //update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //apply steering by rotating the ship object
        shipRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

}
