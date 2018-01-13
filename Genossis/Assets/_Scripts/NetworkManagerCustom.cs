using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MsgTypes
{
    public const short PlayerPrefab = MsgType.Highest + 1;

    public class PlayerPrefabMsg : MessageBase
    {
        public short controllerID;
        public short prefabIndex;
    }
}

public class NetworkController : NetworkManager
{
    [SerializeField] Vector3 playerSpawnPos;
    [SerializeField] GameObject character1;
    [SerializeField] GameObject character2;
    // etc.

    GameObject chosenCharacter; // character1, character2, etc.

    // Instantiate whichever character the player chose and was assigned to chosenCharacter
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {

        var player = (GameObject)GameObject.Instantiate(chosenCharacter, playerSpawnPos, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

    }
}
