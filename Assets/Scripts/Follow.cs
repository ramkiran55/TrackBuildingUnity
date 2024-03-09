using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float followSpeed = 0.005f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, followSpeed);
    }
}
