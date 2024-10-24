using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitSpawnerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnerposition;
    int spawnerI = 10;

    
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine("InstantiateRoomObject");
        }
    }

    IEnumerator InstantiateRoomObject()
    {
        for(int i =0; i<spawnerI; i++)
        {
            PhotonNetwork.InstantiateRoomObject("Unit", spawnerposition.transform.position , Quaternion.identity);

            yield return new WaitForSeconds(5f);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }

}
