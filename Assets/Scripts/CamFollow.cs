using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform location;
    Vector3 diffrance;

    void Start()
    {
        diffrance = transform.position - location.position;
    }

    
    void Update()
    {
        if(Movement.fall == false)
        {
            transform.position = location.position + diffrance;
        }
    }
}
