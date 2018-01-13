using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerNetworkSetup : NetworkBehaviour {

    [SerializeField] Camera FPSCharacterCam;
    [SerializeField] AudioListener audioListener;
	// Use this for initialization
	void Start ()
    {
		if(isLocalPlayer)
        {
            GameObject.Find("SceneCamera").SetActive(false);

            GetComponent<CharacterController>().enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            FPSCharacterCam.enabled = true;
            audioListener.enabled = true;
        }
	}
}
