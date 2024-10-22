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
        //MouseY�� ���콺�� �Է��� ���� �����մϴ�.
        mouseY += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        //mouseY�� ���� -65~65������ ������ �����մϴ�.
        mouseY = Mathf.Clamp(mouseY, -65, 65);
        //mouseY�� Mathf.clamp(�����ϴ� ��,�ּҰ�,�ִ밪)
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);

    }

   
}
