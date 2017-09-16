using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Camera>().aspect = 4f / 3f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
