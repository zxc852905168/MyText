using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skill : MonoBehaviour {
    public Transform[] waypos;
    // public void Hydraarray() {
    // public Transform way;
    // public GameObject soldiers;
    //}
    //长蛇阵
    public float InfantryNumber;
    public float cavalryNumber;
    public float ArcherNumber;
    public float maulerNumber;
    public Text soldtext;
    public float InfantryNeed;
    public float InfantryFood;
    public float InfantryLife;
    public float InfantryDistance;
    public float InfantrySpeed;
    public float InfantryMAX;
    public float InfantryMIN;
    public float InfantryLV;
    public float cavalryNeed;
    public float cavalryFood;
    public float cavalryLife = 2;
    public float cavalryDistance = 1;
    public float cavalrySpeed = 2;
    public float cavalryMAX = 25;
    public float cavalryMIN = 10;
    public float cavalryLV;
    public float ArcherNeed;
    public float ArcherFood;
    public float ArcherLife = 2;
    public float ArcherDistance = 1;
    public float ArcherSpeed = 2;
    public float ArcherMAX = 25;
    public float ArcherMIN = 10;
    public float ArcherLV;
    public float maulerNeed;
    public float maulerFood;
    public float maulerLife = 2;
    public float maulerDistance = 1;
    public float maulerSpeed = 2;
    public float maulerMAX = 25;
    public float maulerMIN = 10;
    public float maulerLV;
    //public string InfantryName;
    public string InfantryName;
    public string cavalryName;
    public string ArcherName;
    public string maulerName;
    //changse
    public IEnumerator Hydraarray(float time, GameObject soldiers, Transform way)
    {
        for (int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(time);
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
        }
    }
    public string readArmsXMLData(string itemName, string value)
    {
        //string fileName = Application.dataPath + "/Data/Arms.xml";
        string fileName = Resources.Load("Arms").ToString();
        return Func.getInstance().readXMLArmsData(fileName, itemName, value);
    }
    public void readMyArmsData()
    {
        //string theName = "";
        // theName = myName();//如果是我的兵种


        InfantryNeed = float.Parse(readArmsXMLData(InfantryName, "Need"));

        cavalryNeed = float.Parse(readArmsXMLData(cavalryName, "Need"));
        ArcherNeed = float.Parse(readArmsXMLData(ArcherName, "Need"));
        maulerNeed = float.Parse(readArmsXMLData(maulerName, "Need"));


    }

    //一字阵
    public void Wordmatrix(GameObject soldiers)
    {
        foreach (Transform WhatWay in waypos)
        {
            GameObject soldier = Instantiate(soldiers, WhatWay.position, WhatWay.rotation) as GameObject;
            soldier.transform.SetParent(WhatWay);

        }
    }
    
    //一夫当关

    //
    /*
    public void soldiersData() {

        switch (InfantryName) {
            case "轻步兵":
                InfantryFood = 5;
                InfantryNeed = 7;
                 InfantryLife=2;
              InfantryDistance=1;
                InfantrySpeed=2;
              InfantryMAX=25;
              InfantryMIN=10;
                break;
            case "重步兵":
                InfantryFood = 5;
                InfantryNeed = 5;
                break;
            case "车兵":
                InfantryFood = 7;
                InfantryNeed = 7;
                break;

        }
        switch (cavalryName)
        {
            case "重骑兵":
                cavalryFood = 5;
                cavalryNeed = 5;
                cavalryLife = 2;
                cavalryDistance = 1;
                cavalrySpeed = 3;
                cavalryMAX = 25;
                cavalryMIN = 10;
                break;
            case "轻骑兵":
                cavalryFood = 5;
                cavalryNeed = 5;
                cavalryLife = 2;
                cavalryDistance = 1;
                cavalrySpeed = 4;
                cavalryMAX = 25;
                cavalryMIN = 10;
                break;
            case "弓骑兵":
                cavalryFood = 5;
                cavalryNeed = 5;
                break;
        }
        switch (ArcherName)
        {
            case "弓兵":
                ArcherFood = 5;
                ArcherNeed = 5;
                ArcherLife = 2;
                ArcherDistance = 1;
                ArcherSpeed = 2;
                ArcherMAX = 25;
                ArcherMIN = 10;
                break;
            case "弩兵":
                ArcherFood = 5;
                ArcherNeed = 5;
                break;
            case "连弩兵":
                ArcherFood = 5;
                ArcherNeed = 5;
                break;

        }
        switch (maulerName)
        {
            case "盾兵":
                maulerFood = 5;
                maulerNeed = 5;
                maulerLife = 2;
                maulerDistance = 1;
                maulerSpeed = 1;
                maulerMAX = 25;
                maulerMIN = 10;
                break;
            case "矛盾兵":
                maulerFood = 5;
                maulerNeed = 5;
                break;
            case "刀盾兵":
                maulerFood = 5;
                maulerNeed = 5;
                break;

        }

    }
    public void soldiersADD(GameObject soldier ,int type)
    {
        switch (type)
        {

            case 1:
                soldier.GetComponent<ALLsoldiers>().Food = InfantryFood;
                soldier.GetComponent<ALLsoldiers>().Need = InfantryNeed;
                soldier.GetComponent<ALLsoldiers>().Life = InfantryLife;
                soldier.GetComponent<ALLsoldiers>().Distance = InfantryDistance;
                soldier.GetComponent<ALLsoldiers>().Speed = InfantrySpeed;
                soldier.GetComponent<ALLsoldiers>().damageMAX = InfantryMAX;
                soldier.GetComponent<ALLsoldiers>().damageMIN = InfantryMIN;
                soldier.GetComponent<ALLsoldiers>().LV = InfantryLV;
                if (this.tag == "Player")
                {
                    if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumber - InfantryNeed >= 0)
                    {
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumber -= InfantryNeed;
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumberText.text = GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().InfantryNumber.ToString();
                    }
                }
                break;
            case 2:
                soldier.GetComponent<ALLsoldiers>().Food = cavalryFood;
                soldier.GetComponent<ALLsoldiers>().Need = cavalryNeed;
                soldier.GetComponent<ALLsoldiers>().Life = cavalryLife;
                soldier.GetComponent<ALLsoldiers>().Distance = cavalryDistance;
                soldier.GetComponent<ALLsoldiers>().Speed = cavalrySpeed;
                soldier.GetComponent<ALLsoldiers>().damageMAX = cavalryMAX;
                soldier.GetComponent<ALLsoldiers>().damageMIN = cavalryMIN;
                soldier.GetComponent<ALLsoldiers>().LV = cavalryLV;
                if (this.tag == "Player")
                {
                    if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().cavalryNumber - cavalryNeed >= 0)
                    {

                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().cavalryNumber -= cavalryNeed;
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().CavalryNumberText.text = GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().cavalryNumber.ToString();
                    }
                }
                //GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                break;
            case 3:
                soldier.GetComponent<ALLsoldiers>().Food = ArcherFood;
                soldier.GetComponent<ALLsoldiers>().Need = ArcherNeed;
                soldier.GetComponent<ALLsoldiers>().Life = ArcherLife;
                soldier.GetComponent<ALLsoldiers>().Distance = ArcherDistance;
                soldier.GetComponent<ALLsoldiers>().Speed = ArcherSpeed;
                soldier.GetComponent<ALLsoldiers>().damageMAX = ArcherMAX;
                soldier.GetComponent<ALLsoldiers>().damageMIN = ArcherMIN;
                soldier.GetComponent<ALLsoldiers>().LV = ArcherLV;
                if (this.tag == "Player")
                {
                    if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumber - ArcherNeed >= 0)
                    {



                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumber -= ArcherNeed;
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumberText.text = GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().ArcherNumber.ToString();
                    }
                }
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                break;
            case 4:
                soldier.GetComponent<ALLsoldiers>().Food = maulerFood;
                  soldier.GetComponent<ALLsoldiers>().Need= maulerNeed;
                 soldier.GetComponent<ALLsoldiers>().Life= maulerLife ;
                soldier.GetComponent<ALLsoldiers>().Distance= maulerDistance ;
                soldier.GetComponent<ALLsoldiers>().Speed= maulerSpeed ;
                soldier.GetComponent<ALLsoldiers>().damageMAX= maulerMAX  ;
                 soldier.GetComponent<ALLsoldiers>().damageMIN= maulerMIN ;
                soldier.GetComponent<ALLsoldiers>().LV= maulerLV ;
                if (this.tag == "Player")
                {
                    if (GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumber - maulerNeed >= 0)
                    {
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumber -= maulerNeed;
                        GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumberText.text = GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().maulerNumber.ToString();
                    }
                }
                //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                break;


        }

   
        }*/
}
