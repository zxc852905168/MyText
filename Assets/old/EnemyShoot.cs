using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class EnemyShoot : Skill
{
    public Button[] ManualButton;
    public GameObject ButtonControl;
    public GameObject StrongArrow;
    public GameObject arrow;
    public GameObject Infantry;
    public GameObject cavalry;
    public GameObject Archer;
    public GameObject mauler;
    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform way4;
    public GameObject autoToggle;
    public GameObject ManualToggleSoldier;
    public float maxTime;
    public float minTime;
    // public Text soldtext;
    public Text foodtext;
    //public Text ensoldtext;
    // public Text enfoodtext;
    public GameObject battlecontrol;
    public float placeSoldiers;
    // public float placemonny;
    public float placefoodstuff;
    public bool isautos = true;
    // Use this for initialization
    void Start()
    {

    }
    private void OnEnable()
    {
        // UIcontrol.gamestrat1 += Startbatte;
        BattleManager.battleOver += gameover;
    }
    /*
    public void enemySkill2()
    {
        float randomPoint = Random.value * 100;
        //print(randomPoint);
        if (randomPoint <= 25)
        {
            print("Wordmatrix");
            Wordmatrix(Infantry);
        }
        if (randomPoint > 25 && randomPoint <= 50)
        {
            print("Wordmatrix");
            StartCoroutine(Hydraarray(0.5f, Infantry, chooseWay()));
        }
        if (randomPoint > 50 && randomPoint <= 75)
        {
            StartCoroutine(jiXinZhen(0.5f, cavalry));
        }
        if (randomPoint > 75 && randomPoint <= 100)
        {
            OneMan(mauler);
        }

    }*/
    public void skillPanDuan1() {
        float randomPoint = Random.value * 100;
        //print(randomPoint);
        if (randomPoint <= 25)
        {
            if (BattleManager.getInstance().EmInfantryNumber >= InfantryNeed * 4)
            {
                Wordmatrix(Infantry);
            }
            else
            {
                randomPoint = 40;//判断下一个，究极硬编码
            }
        }
        if (randomPoint > 25 && randomPoint <= 50)
        {
            if (BattleManager.getInstance().EmInfantryNumber >= InfantryNeed * 4)
            {

                StartCoroutine(Hydraarray(0.5f, Infantry, chooseWay()));
            }
            else
            {
                randomPoint = 55;
            }
        }
        if (randomPoint > 50 && randomPoint <= 75)

        {
            if (BattleManager.getInstance().EmcavalryNumber >= cavalryNeed * 4)
            {
                StartCoroutine(jiXinZhen(0.5f, cavalry));
            }
            else
            {
                randomPoint = 90;
            }
        }
        if (randomPoint > 75 && randomPoint <= 100)
        {
            if (BattleManager.getInstance().EmmaulerNumber >= maulerNeed)
            {
                OneMan(mauler);
            }
            else
            {


            }
        }

    }
    // Update is called once per frame
    //敌人技能
    public void enemySkill() {
        //print("cb");
        if (EventManager.getInstance().advanceStatus == EventStatus.sanZhai)
        {

            skillPanDuan1();
        }
       

       
        if (EventManager.getInstance().advanceStatus == EventStatus.junZhi)
        {

            skillPanDuan1();
        }

        if (EventManager.getInstance().advanceStatus == EventStatus.xianChen)
        {
            skillPanDuan1();

        }
        if (EventManager.getInstance().advanceStatus == EventStatus.qiYiJun)
        {
            skillPanDuan1();

        }
        if (EventManager.getInstance().advanceStatus == EventStatus.guanBin)
        {
            float randomPoint = Random.value * 100;
            //print(randomPoint);
            if (randomPoint <= 25)
            {
                Wordmatrix(Infantry);
            }
            if (randomPoint > 25 && randomPoint <= 50)
            {

                StartCoroutine(Hydraarray(0.5f, Infantry, chooseWay()));
            }
            if (randomPoint > 50 && randomPoint <= 75)
            {
                StartCoroutine(jiXinZhen(0.5f, cavalry));
            }
            if (randomPoint > 75 && randomPoint <= 100)
            {
                OneMan(mauler);
            }


        }


    }
    //choooseWay
    public Transform chooseWay() {
        Transform wayChoose;
        float randomPoint2 = Random.value * 100;
        //print(randomPoint);
        if (randomPoint2 <= 25)
        {
            wayChoose = way1;
            return wayChoose;
        }
        if (randomPoint2 > 25 && randomPoint2 <= 50)
        {
            wayChoose = way2;
            return wayChoose;

        }
        if (randomPoint2 > 50 && randomPoint2 <= 75)
        {
            wayChoose = way3;
            return wayChoose;
        }
        if (randomPoint2 > 75 && randomPoint2 <= 100)
        {
            wayChoose = way4;
            return wayChoose;
        }
        else
        {
            return way1;
        }
    } 
    //不同的时间
    public void timeReady()
    {
        if (EventManager.getInstance().advanceStatus == EventStatus.sanZhai)
        {
            minTime = 1.8f;
            maxTime = 2.4f;
        }
        //郡治是否进攻文本
        if (EventManager.getInstance().advanceStatus == EventStatus.junZhi)
        {

            minTime = 1.6f;
            maxTime = 2f;
        }

        if (EventManager.getInstance().advanceStatus == EventStatus.xianChen)
        {
            minTime = 1.7f;
           maxTime = 2.2f;

        }
        if (EventManager.getInstance().advanceStatus == EventStatus.qiYiJun)
        {

            minTime = 1.6f;
            maxTime = 2.1f;

        }


    }

    //设置自动

    public void Startbatte()
        {
        //
        // soldiersData();
        InfantryName = GameManager.getInstance().playerData.AiArms. InfantryName;
        cavalryName = GameManager.getInstance().playerData.AiArms.cavalryName;
        ArcherName = GameManager.getInstance().playerData.AiArms.ArcherName;
        maulerName = GameManager.getInstance().playerData.AiArms.maulerName;
        timeReady();
        readMyArmsData();//读取need数据
      StartCoroutine(PlayerAttack());
       // skillReady();
            // StartCoroutine(Hydraarray(0.5f, Infantry, way1));
            // Wordmatrix(Infantry);
            // StartCoroutine(ThousandArrows(0.5f, arrow));
            // strongArrows(StrongArrow);

    }
        public void stopbatte()
        {

            this.GetComponent<EnemyShoot>().enabled = false;
            // StartCoroutine(PlayerAttack());
            StopCoroutine(PlayerAttack());

        }
        IEnumerator PlayerAttack()
    {
        while (true) {

            AIchooseSoldier(chooseAttackWay());
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            if (BattleManager.getInstance().enemySolidrNumber < 3)
            {
              //  StartCoroutine(PlayerAttack());
               // StopAllCoroutines();
                break;
                
            }
        } Debug.Log("After 3s");
        }
        /* //*自动选择兵道
         public void AIchooseAttackWay()
         {
             //Instantiate(Infantry, way1.position, Quaternion.identity);

             float randomPoint = Random.value * 100;

             if (randomPoint <= 25)
             {
                 AIchooseSoldier(way1);
             }
             if (randomPoint > 25 && randomPoint <= 50)
             {
                 AIchooseSoldier(way2);
             }
             if (randomPoint > 50 && randomPoint <= 75)
             {
                 AIchooseSoldier(way3);
             }
             if (randomPoint > 75 && randomPoint <= 100)
             {
                 AIchooseSoldier(way4);
             }
         }*/
        //自动选择兵种
        public void AIchooseSoldier(Transform way)
        {
            //Instantiate(Infantry, way1.position, Quaternion.identity);

            float randomPoint = Random.value * 100;

            if (randomPoint <= 21)
            {
            if (BattleManager.getInstance().EmmaulerNumber >= maulerNeed)
            {
                GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                //soldiersADD(go, 4);
                //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(InfantryFood, InfantryNeed);
                go.transform.SetParent(way);
            }
            else
            {
                randomPoint = 30;
            }
        }
            if (randomPoint > 21 && randomPoint <= 45)
            {
            if (BattleManager.getInstance().EmcavalryNumber >= cavalryNeed)
            {
                GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
                // soldiersADD(go, 2);
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(cavalryFood, cavalryNeed);
                go.transform.SetParent(way);
            }
            else
            {
                randomPoint = 50;
            }
        }
            if (randomPoint > 45 && randomPoint <= 72)
            {
            if (BattleManager.getInstance().EmArcherNumber >= ArcherNeed)
            {
                GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                // soldiersADD(go, 3);
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(ArcherFood, ArcherNeed);
                go.transform.SetParent(way);
            }
            else
            {
                randomPoint = 78;
            }
        }
            if (randomPoint > 72 && randomPoint <= 100)
            {
            if (BattleManager.getInstance().EmInfantryNumber >= InfantryNeed)
            {
                GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                // soldiersADD(go, 1);
                //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIfooddamage(InfantryFood, InfantryNeed);
                go.transform.SetParent(way);
            }
            else
            {
               // AIchooseSoldier(chooseAttackWay());
            }
        }
        }
        //自动选择兵道
        public Transform chooseAttackWay()
        {
            //Instantiate(Infantry, way1.position, Quaternion.identity);

            float randomPoint = Random.value * 100;

            if (randomPoint <= 25)
            {
                return way1;
            }
            if (randomPoint > 25 && randomPoint <= 50)
            {
                return way2;
            }
            if (randomPoint > 50 && randomPoint <= 75)
            {
                return way3;
            }
            if (randomPoint > 75 && randomPoint <= 100)
            {
                return way4;
            }
            else
            {
                return way1;

            }

        }
    //疾行阵
    public IEnumerator jiXinZhen(float time, GameObject soldiers)
    {
        for (int i = 0; i < 4; i++)
        {
            Transform way = chooseWay();
            yield return new WaitForSeconds(time);
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
        }
    }
    //一夫当关
    public void OneMan(GameObject soldiers)
        {

            Transform way = chooseAttackWay();
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
        soldier.GetComponent<EnemyMauler>().setOneMan();
        soldier.transform.SetParent(way);

        }
        //万箭穿心

        IEnumerator ThousandArrows(float time, GameObject arrow)
        {
            for (int i = 0; i < 8; i++)
            {
                Transform way = chooseAttackWay();
                yield return new WaitForSeconds(time);
                GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
                soldier.transform.SetParent(way);
            }

        }
        //百步穿杨
        public void strongArrows(GameObject arrow)
        {
            Transform way = chooseAttackWay();

            GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);

        }
    public void gameover()
    {
        BattleManager.battleOver -= gameover;
        StopAllCoroutines();
    }
    void Awake()
    {
        es = this;
        //Screen.SetResolution(360,640,false);//设置分辨率

    }
    private static EnemyShoot es;
    public static EnemyShoot getInstance()
    {

        return es;
    }
}

