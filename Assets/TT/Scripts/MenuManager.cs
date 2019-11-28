using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject NameScreen, ConnectScreen, CreateUserNameButton;
        
  [SerializeField]
  private InputField UserNameInput, CreateRoomInput, JoinRoomInput;


    private void Awake()
    {
        // Connect to Phton Server
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        Debug.Log("Connected to Lobby");

    }


    #region UIMethods

    public void OnClick_CreateNameBtn()
    {

        if(UserNameInput.text.Length >= 2)
        {
            PhotonNetwork.NickName = UserNameInput.text;
            NameScreen.SetActive(false);
            ConnectScreen.SetActive(true);

        }
        
    }


    public void OnNameField_Changed()
    {
        if (UserNameInput.text.Length >= 0)
        {
            CreateUserNameButton.SetActive(true);
        }
        else
        {
            CreateUserNameButton.SetActive(false);
        }
    }
    
    #endregion
}
