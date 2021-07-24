using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInputField;
    public InputField joinInputField;
    public GameObject waiting;
    public void createRoom() {
        PhotonNetwork.CreateRoom(createInputField.text);
    }
    public void joinRoom() {
        PhotonNetwork.JoinRoom(joinInputField.text);
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.PlayerList.Length > 1)
        {
            PhotonNetwork.LoadLevel("Main");
        }
        else {
            waiting.SetActive(true);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.PlayerList.Length > 1)
        {
            PhotonNetwork.LoadLevel("Main");
        }
    }
}
