using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTest : MonoBehaviour {
    public Transform t;
    public Text text;
    int index = 0;
    Tweener temp;
    // Use this for initialization
    void Start () {
        //temp = t.DOMove(Vector3.zero, 3f).From();
        //temp.SetEase(Ease.Unset + index);
        //temp.Restart();
        //temp.Pause();
	}

	public void go()
    {
        temp.Kill();
        index++;
        Start();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
