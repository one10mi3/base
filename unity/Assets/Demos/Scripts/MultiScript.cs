using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class MultiScript : MonoBehaviourPunCallbacks
{
    public GameObject PhotonObject;
    //public GameObject PhotonObject2;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("マスターサーバーに接続しました");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby() {
        Debug.Log("ロビーへ参加しました");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOption);
    }

    public override void OnJoinedRoom() {
        Debug.Log("ルームへ参加しました");
        PhotonNetwork.Instantiate(
          PhotonObject.name,
          new Vector3(0f,1f,0f),
          Quaternion.identity,
          0
        );

        
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.GetComponent<UnityChan.ThirdPersonCamera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
