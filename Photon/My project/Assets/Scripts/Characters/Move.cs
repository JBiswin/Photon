using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
     Vector3 moveInput;

   
    float jumpSpeed;

    private void Start()
    {
        moveInput = Vector3.zero;
    }
    public void Movement(Rigidbody rigidbody)
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(Horizontal, 0, Vertical).normalized;
        rigidbody.position += rigidbody.transform.TransformDirection(moveInput * speed * Time.deltaTime);

    }





}
