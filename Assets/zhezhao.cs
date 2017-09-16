using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhezhao : MonoBehaviour {

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
    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // this.GetComponent<Text>().enabled=false;
            Tips.getInstance().setText("接下来做什么呢");
            //  MenuManager.getInstance().mainButtonUp();
            this.gameObject.SetActive(false);
            //  this.GetComponent<Text>().text = "";
            // this.GetComponent<Text>().enabled = false;
            //uicontrol.GetComponent<UIcontrol>().OnOUT();
        }

    }
}
