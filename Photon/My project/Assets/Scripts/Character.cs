using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    Rigidbody rigidbody;

    public Move move;
    public Rotation rotation;
    public Head head;
    float power = 4.8f;
    float inclination = 40;

    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidbody = GetComponent<Rigidbody>();
        head = GetComponent<Head>();
    }
    void Start()
    {
        DisableCamera();
    }

   
    void Update()
    {
        

        rotation.InputRotateY();

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            move.Movement(rigidbody);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.E))
        {
            
        }
    

        else if(Input.GetKey(KeyCode.Q))
        {
          
        }

        rotation.RotateY(rigidbody);
    }

    private void FixedUpdate()
    {
        
    }

    public void DisableCamera()
    {
        //현재 플레이가 나 자신이라면
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }

        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
