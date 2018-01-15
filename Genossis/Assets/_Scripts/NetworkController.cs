using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class NetworkMessage : MessageBase
{
    public int chosenClass;
}

public class NetworkController : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        int index;

        if (numPlayers == 0)
        {
            playerPrefab = spawnPrefabs[0];
        }
        else
            playerPrefab = spawnPrefabs[1];


        /* GameObject player;

         player = (GameObject)Object.Instantiate(this.playerPrefab, Vector3.zero, Quaternion.identity);
         NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
         */
        base.OnServerAddPlayer(conn, playerControllerId);
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        ClientScene.AddPlayer(conn, 0);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        //base.OnClientConnect(conn);
    }
}
