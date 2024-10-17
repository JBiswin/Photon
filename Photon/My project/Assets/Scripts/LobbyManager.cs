using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
   
    [SerializeField] Canvas lobbyCanvas;
    



    private void Awake()
    {
        if(PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        // ������ �����ϴ� �Լ�
        PhotonNetwork.ConnectUsingSettings();

        lobbyCanvas.gameObject.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        if (lobbyCanvas.gameObject.activeSelf)
        {
            lobbyCanvas.gameObject.SetActive(true);
        }

    }

    public override void OnConnectedToMaster()
    {
        // joinLobby : Ư�� �κ� �����Ͽ� �����ϴ� ����
        PhotonNetwork.JoinLobby(new TypedLobby("Default" , LobbyType.Default));

    }

}