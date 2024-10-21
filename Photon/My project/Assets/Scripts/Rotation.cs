using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float mouseX;
    float speed = 300f;

    public void RotateY()
    {
        mouseX += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
