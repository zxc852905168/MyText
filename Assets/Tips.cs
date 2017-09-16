using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tips : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setAtice(bool v)
    {
        this.gameObject.SetActive(v);
    }
    public void setText(string str)
    {
        this.gameObject.GetComponent<Text>().text = str;
    }
    void Awake()
    {
        ts = this;


    }
    private static Tips ts;
    public static Tips getInstance()
    {

        return ts;
    }
}
