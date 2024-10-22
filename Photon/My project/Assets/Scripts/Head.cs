using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviour
{
    Rotation rotation;
    

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.RotateX();
    }

    
}
