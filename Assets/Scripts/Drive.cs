using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float forwardSpeed = 10.0f;
    public float nitroBoost = 20;
    public float rotateSpeed = 8f;

    float currentSpeed = 0;
    public float acceleration = 10;
    public float deceleration = 5;
    public float maxSpeed = 10;
    // Start is called before the first frame update

    public GameObject[] wheels;
    Renderer rend;
    float wheelCircumference;

    Rigidbody rb;
    void Start()
    {
        //this.transform.Translate(-1, 0, 0);
        rend = wheels[0].GetComponent<Renderer>();
        wheelCircumference = rend.bounds.size.y * Mathf.PI;

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        //AddNitroBoost();
        //MoveCar();
        MoveWithAcceleration();
    }

    void MoveCar()
    {
        // Drive car forward and backward with user input
        float forwardInput = Input.GetAxis("Vertical") * forwardSpeed;
        this.transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);

        // Steer car left and right with user input
        float rotateInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        this.transform.Rotate(0, rotateInput, 0);
    }

    void AddNitroBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            forwardSpeed += nitroBoost;
        if (Input.GetKeyUp(KeyCode.Space))
            forwardSpeed -= nitroBoost;

    }

    void MoveWithAcceleration()
    {
        // Drive car forward and backward with user input
        float forwardInput = Input.GetAxisRaw("Vertical");

        if (currentSpeed < maxSpeed && currentSpeed > -maxSpeed)
        {
            currentSpeed += acceleration * forwardInput * Time.deltaTime;
        }
        else
        {
            Deceleration();
        }

        if (forwardInput == 0)
        {
            Deceleration();
        }
        this.transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Steer car left and right with user input
        float rotateInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        this.transform.Rotate(0, rotateInput * currentSpeed, 0);
        RotateWheels();
    }

    void Deceleration()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        if (currentSpeed < 0)
        {
            currentSpeed += deceleration * Time.deltaTime;
        }
    }

    void RotateWheels()
    {
        foreach(GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.left * (currentSpeed / wheelCircumference) * 360 * Time.deltaTime);
        }
    }
}
