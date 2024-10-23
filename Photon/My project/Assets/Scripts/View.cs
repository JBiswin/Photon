using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

[RequireComponent(typeof(Character))]
public class View : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickMane;
    [SerializeField] Camera remoteCamera;

    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    private void Start()
    {
        nickMane.text = photonView.Owner.NickName;
        
    }

    private void Update()
    {
       transform.forward = remoteCamera.transform.forward;
    }

}
