using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEvents : MonoBehaviour {

	public Camera[] cams;

	public void camMain()
	{
		cams [0].enabled = true;
		cams [1].enabled = false;
	}

	public void camMJ()
	{
		cams [0].enabled = false;
		cams [1].enabled = true;
	}

}
