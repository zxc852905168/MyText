using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        sm= this;
     

    }
    private static SoldiersManager sm;
    public static SoldiersManager getInstance()
    {

        return sm;
    }
}
