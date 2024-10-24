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
        //Prefab�� �ϳ� ������ ���� text���� �����մϴ�.

        GameObject talk = Instantiate(Resources.Load<GameObject>("string"));

        talk.GetComponent<Text>().text = message;

        //��ũ�� �� - Content�� �ڽ����� ����մϴ�.

        talk.transform.SetParent(parentTransform);

        //ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.

        inputField.ActivateInputField();

        //inputfield�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.

        inputField.text = null;

    }
}
