using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Add(1, 2, 3);
        Debug.Log(Substract(20, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Add(int firstNumber, int secondNumber, int thirdNumber)
    {
        Debug.Log(firstNumber + secondNumber + thirdNumber);
    }

    int Substract(int a, int b)
    {
        return (a - b);
    }
}
