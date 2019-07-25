using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    public GameObject  awake;
    public InputField ip;
 
  

    public void Start_server ()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = ip.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        CreateRoom();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinedLobby");
    }

    public void CreateRoom ()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        Debug.Log("Create");

    }

    public void JoinRoom ()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {

        Debug.Log("Joined"); 
        awake.SetActive(false);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player+");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player-");
    }

    void Update()
    {
        
    }
}
