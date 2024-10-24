using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float speed = 300f;
    
    public void InputRotateY()
    {
      
        mouseX += Input.GetAxis("Mouse X") * speed* Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidbody)
    {
       
        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        //MouseY에 마우스로 입력한 값을 저장합니다.
        mouseY += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        //mouseY의 값을 -65~65사이의 값으로 제한합니다.
        mouseY = Mathf.Clamp(mouseY, -65, 65);
        //mouseY에 Mathf.clamp(제한하는 값,최소값,최대값)
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);

    }

   
}
