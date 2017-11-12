using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour {

    public GameObject gameObject;
	private Vector3 pos = Vector3.zero;
	// Use this for initialization
	void Start () {
		pos = this.transform.position;
		pos.y = 5;//A changer surement

        gameObject.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
        pos = this.transform.position;
        pos.y = 5;//A changer surement

        gameObject.transform.position = pos;
    }
}
