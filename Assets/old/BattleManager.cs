using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour {
    public float InfantryNumber;
    public float cavalryNumber;
    public float ArcherNumber;
    public float maulerNumber;
    public float EmInfantryNumber;
    public float EmcavalryNumber;
    public float EmArcherNumber;
    public float EmmaulerNumber;
    public float mySolidrNumber;
    public float myFood;
    public float enemySolidrNumber;//duAI
    public float enemyFood;
    public float enemyMoney;
    public Text CavalryNumberText;
    public Text InfantryNumberText;
    public Text ArcherNumberText;
    public Text maulerNumberText;
    public Text mysoldtext;
    public Text myfoodtext;
    public Text ensoldtext;
    public Text enfoodtext;
    public Text battleTime;
    public Text Tip;
    public GameObject myshoot;
    public GameObject enshoot;
    public GameObject skillButton;
    public delegate void BattleOver();
    public static event BattleOver battleOver;
    // Use this for initialization
    void Start () {
       
    }
    private void OnEnable()
    {
        // UIcontrol.gamestrat1 += Startbatte;
        BattleManager.battleOver += gameover;
    }
    public void battleStart()
    {
        readTheData();

        MyShoot.getInstance().Startbatte();
        EnemyShoot.getInstance().Startbatte();
        skillButton.SetActive(true);
        //计时
        float time = 0;
       StartCoroutine(Timer(time));
        startText();
        GameManager.getInstance().pauseSound();
    }
    public void startText() {

        ensoldtext.text = ((int)enemySolidrNumber).ToString();
        InfantryNumberText.text = ((int)InfantryNumber).ToString();
        ArcherNumberText.text = ((int)ArcherNumber).ToString();
        maulerNumberText.text = ((int)maulerNumber).ToString();
        CavalryNumberText.text = ((int)cavalryNumber).ToString();
        enfoodtext.text = ((int)enemyFood).ToString();
        myfoodtext.text = ((int)myFood).ToString();
        mysoldtext.text = ((int)mySolidrNumber).ToString();

    }
    // Update is called once per frame
    void Update () {

    }
    public IEnumerator Timer(float time)
    {
        int NUM12 = 12;
        while (true)
        {
            yield return new WaitForSeconds(1);
            print(time);
           
            time++;
            battleTime.text = ((int)time).ToString();
            if (time== NUM12) {
                EnemyShoot.getInstance().enemySkill();
                NUM12 += 12;
            }
            //敌人释放技能
        }
    }
    //读数据
    public void readTheData()
    {
        enemySolidrNumber = GameManager.getInstance().playerData.AiArms.placeSoldiers;
        print(enemySolidrNumber);
        enemyFood = GameManager.getInstance().playerData.AiArms.placeFood;
        enemyMoney = GameManager.getInstance().playerData.AiArms.placeMonny;
        EmInfantryNumber = enemySolidrNumber* 0.4f;
        EmcavalryNumber = enemySolidrNumber * 0.3f;
        EmArcherNumber = enemySolidrNumber * 0.2f;
        EmmaulerNumber = enemySolidrNumber * 0.1f;
        InfantryNumber = GameManager.getInstance().playerData.InfantryNumber;
        cavalryNumber = GameManager.getInstance().playerData.cavalryNumber;
        ArcherNumber = GameManager.getInstance().playerData.ArcherNumber;
        maulerNumber = GameManager.getInstance().playerData.maulerNumber;
        myFood = GameManager.getInstance().playerData.liangCao;
        mySolidrNumber = InfantryNumber + cavalryNumber + ArcherNumber + maulerNumber;

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
    //duqusj
    public void readData()
    {

    }
    //战斗结算
    public void ballteSettlement()
    {

    }
    //我的士兵减少
    public void mySoilderReduce(float soilder,string tag)
    {
        mySolidrNumber -= soilder;
        print(mySolidrNumber);
        switch (tag)
        {
            case "Infantry":
                InfantryNumber -= soilder;
                InfantryNumberText.text = ((int)InfantryNumber).ToString();
                break;

            case "Archer":
                ArcherNumber -= soilder;
                ArcherNumberText.text = ((int)ArcherNumber).ToString();
                break;
            case "mauler":
                maulerNumber -= soilder;
                maulerNumberText.text = ((int)maulerNumber).ToString();
                break;
            case "cavalry":
                cavalryNumber -= soilder;
                CavalryNumberText.text = ((int)cavalryNumber).ToString();
                break;

        }
        float allsoldier = InfantryNumber + ArcherNumber + maulerNumber + cavalryNumber;
        mysoldtext.text = ((int)allsoldier).ToString();
      //  mysoldtext.text = ((int)mySolidrNumber).ToString();
    }
    public void enemySoilderReduce(float soilder,string tag)
    {
        print("xh");
        enemySolidrNumber -= soilder;
        //  print(enemySolidrNumber);
        switch (tag)
        {
            case "EnemyInfantry":
                EmInfantryNumber -= soilder;
                break;

            case "EnemyArcher":
                EmArcherNumber -= soilder;
                break;
            case "Enemymauler":
                EmmaulerNumber -= soilder;
                break;
            case "Enemycavalry":
                EmcavalryNumber -= soilder;
                break;

        }
        ensoldtext.text = ((int)(EmInfantryNumber + EmmaulerNumber + EmcavalryNumber + EmArcherNumber)).ToString();
    }
    public void myFoodReduce(float food)
    {
        myFood -= food;
        myfoodtext.text = ((int)myFood).ToString();
    }
    public void enemyFoodReduce(float food)
    {
        enemyFood -= food;
        enfoodtext.text = ((int)enemyFood).ToString();
    }
    //破坏
    public void myDamage(float Damage)//随机数
    {
       /* mySolidrNumber -= Damage;
        if (mySolidrNumber <= 0)
        {
            battleOver();
            EventManager.getInstance().failEvent();
           

        }*/
        float DamagePart = Damage;
        print("Damage" + Damage);
        //   EmInfantryNumber -= Damage;

        //  battleOver();
        // EventManager.getInstance().winEvent();
        //  BattleManager.BattleOver();

        //伤害计算
        if (DamagePart < InfantryNumber)
        {
            InfantryNumber -= DamagePart;
            InfantryNumberText.text = ((int)InfantryNumber).ToString();
        }
        else
        {
            if (InfantryNumber >= 1)
            {
                DamagePart -= InfantryNumber;
                InfantryNumber = 0;
                InfantryNumberText.text = ((int)InfantryNumber).ToString();
            }
            if (Damage < ArcherNumber)
            {
                ArcherNumber -= Damage;
                ArcherNumberText.text = ((int)ArcherNumber).ToString();
            }
            else
            {

                if (ArcherNumber >= 1)
                {
                    DamagePart -= ArcherNumber;
                    ArcherNumber = 0;
                    ArcherNumberText.text = ((int)ArcherNumber).ToString();

                }
                if (DamagePart < cavalryNumber)
                {
                    cavalryNumber -= DamagePart;
                    CavalryNumberText.text = ((int)cavalryNumber).ToString();
                }
                else
                {
                    if (cavalryNumber >= 1)
                    {
                        DamagePart -= cavalryNumber;
                        cavalryNumber = 0;
                        CavalryNumberText.text = ((int)cavalryNumber).ToString();

                    }
                    if (DamagePart < maulerNumber)
                    {
                        maulerNumber -= DamagePart;
                        maulerNumberText.text = ((int)maulerNumber).ToString();
                    }
                    else
                    {
                        if (maulerNumber >= 1)
                        {
                            DamagePart -= maulerNumber;
                            maulerNumber = 0;
                            maulerNumberText.text = ((int)maulerNumber).ToString();
                        }
                        
                        EventManager.getInstance().failEvent();
                        battleOver();
                    }
                }
            }

        }
        //士兵计算，总量
        float allsoldier = InfantryNumber + ArcherNumber + maulerNumber + cavalryNumber;
        mysoldtext.text = ((int)allsoldier).ToString();
    }
    public void enemyDamage(float Damage)//随机数
    { float DamagePart= Damage;
        print("Damage"+ Damage);
     //   EmInfantryNumber -= Damage;
       
          //  battleOver();
           // EventManager.getInstance().winEvent();
        //  BattleManager.BattleOver();
            
      //伤害计算
        if (DamagePart < EmInfantryNumber)
        {
            EmInfantryNumber -= DamagePart;
        }
        else {
            if (EmInfantryNumber>=1) {
                DamagePart -= EmInfantryNumber;
                EmInfantryNumber = 0;
              
            }
            if (Damage < EmArcherNumber)
            {
                EmArcherNumber -= Damage;
            }
            else {

                if (EmArcherNumber >= 1)
                {
                    DamagePart -= EmArcherNumber;
                    EmArcherNumber = 0;

                }
                if (DamagePart < EmcavalryNumber)
                {
                    EmcavalryNumber -= DamagePart;
                }
                else {
                    if (EmcavalryNumber >= 1)
                    {
                        DamagePart -= EmcavalryNumber;
                        EmcavalryNumber = 0;

                    }
                    if (DamagePart < EmmaulerNumber)
                    {
                        EmmaulerNumber -= DamagePart;
                    }
                    else {
                        if (EmmaulerNumber >= 1)
                        {
                            DamagePart -= EmmaulerNumber;
                            EmmaulerNumber = 0;

                        }
                        
                        EventManager.getInstance().winEvent();
                        battleOver();
                    }
                }
            }

        }
        ensoldtext.text = ((int)(EmInfantryNumber+ EmmaulerNumber+ EmcavalryNumber+ EmArcherNumber)).ToString();
    }
    public void OnEvacuate()
    {
        Tips.getInstance().setText("接下来该怎么做呢？");
        this.gameObject.SetActive(false);
        battleOver();
        //mainButtonUp();
    }
    public void gameover()
    {
        GameManager.getInstance().playerData.cavalryNumber =(int) cavalryNumber;
        GameManager.getInstance().playerData.InfantryNumber = (int)InfantryNumber;
        GameManager.getInstance().playerData.ArcherNumber = (int)ArcherNumber;
        GameManager.getInstance().playerData.maulerNumber = (int)maulerNumber;
        GameManager.getInstance().playSound();
      BattleManager.battleOver -= gameover;
        StopAllCoroutines();
    }
    void Awake()
    {
        bm= this;
        

    }
    private static BattleManager bm;
    public static BattleManager getInstance()
    {

        return bm;
    }
}
