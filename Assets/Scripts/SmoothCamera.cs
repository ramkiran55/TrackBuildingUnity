using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;
    public float cameraStickness = 10f;
    public float cameraRotationSpeed = 5;
    public Transform cameraOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, cameraOffset.position, cameraStickness * Time.deltaTime);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(car.transform.forward), cameraRotationSpeed * Time.deltaTime);
    }
}
