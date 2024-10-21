using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;

    public Move move;
    public Rotation rotation;

    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
    }
    void Start()
    {
        DisableCamera();
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            move.Movement();
        }

        rotation.RotateY();
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
