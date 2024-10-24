using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{

    [SerializeField] InputField inputField;

    [SerializeField] Transform parentTransform;
    

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if(inputField.text.Length <=0)
            {
                return;
            }

            string talk = photonView.Owner.NickName + ":" + inputField.text;

            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        //Prefab을 하나 생성한 다음 text값을 설정합니다.

        GameObject talk = Instantiate(Resources.Load<GameObject>("string"));

        talk.GetComponent<Text>().text = message;

        //스크롤 뷰 - Content에 자식으로 등록합니다.

        talk.transform.SetParent(parentTransform);

        //채팅을 입력한 후에도 이어서 입력할 수 있도록 설정합니다.

        inputField.ActivateInputField();

        //inputfield의 텍스트를 초기화합니다.

        inputField.text = null;

    }
}
