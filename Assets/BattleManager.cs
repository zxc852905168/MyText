using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //读取数据
  public  void readData()
    {

    }
    //我的士兵发射
    public void mySoilderShoot()
    {

    }
    //敌人的士兵发射
    public void enemySoilderShoot()
    {

    }

    //战斗结算
    public void ballteSettlement()
    {

    }
    private static BattleManager2 bm;
    public static BattleManager2 getInstance()
    {

        return bm;
    }
}
