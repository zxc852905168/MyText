using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cilckUi : MonoBehaviour {

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
        Tips.getInstance().setText("");
        this.gameObject.GetComponent<Text>().text = str;
    }
  
    void Awake()
    {
        ts = this;


    }
    private static cilckUi ts;
    public static cilckUi getInstance()
    {

        return ts;
    }
}
