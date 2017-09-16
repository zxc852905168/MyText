using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyShoot : Skill
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
    public GameObject chooseWayButton;
    public GameObject skillButton;
    public GameObject ManualToggleSoldier;
    public AudioClip xuanZheSound;//选择兵种音效
    public AudioClip[] gongBinSound;
    public AudioClip[] qiBinSound;
    public AudioClip[] buBinSound;
    public AudioClip[] dunBinSound;
    public int gongBinSoundSign;
    public int qiBinSoundSign;
    public int buBinSoundSign;
    public int dunBinSoundSign;
    private AudioSource _audioSource;
    public Text foodtext;
    //public Text ensoldtext;
   // public Text enfoodtext;
    public GameObject battlecontrol;
    public float placeSoldiers;
    // public float placemonny;
    public float placefoodstuff;
    public bool isautos=true;
    // Use this for initialization
    void Start() {
        gongBinSoundSign=0;
   qiBinSoundSign=0;
     buBinSoundSign=0;
     dunBinSoundSign=0;
}

    // Update is called once per frame
    void Update() {
        
    }
    private void OnEnable()
    {
        // UIcontrol.gamestrat1 += Startbatte;
        BattleManager.battleOver += gameover;
    }
    //设置自动
    public void automatic(bool isauto) {
        // isautos = isauto;
        //if (this.tag=="Player") {
            isautos = autoToggle.GetComponent<Toggle>().isOn;
        ///ButtonControl.SetActive(true);
        // print(isauto);
        if (isautos == true)
        {

            Startbatte();
            chooseWayButton.SetActive(false);
        }
        else {
            chooseWayButton.SetActive(true);
        }
       // }
    }
    public void Startbatte() {
        //
        // soldiersData();
        InfantryName = GameManager.getInstance().playerData.InfantryName;
         cavalryName = GameManager.getInstance().playerData.cavalryName;
        ArcherName = GameManager.getInstance().playerData.ArcherName;
        maulerName = GameManager.getInstance().playerData.maulerName;
        readMyArmsData();//读取need数据
        StartCoroutine(PlayerAttack());
        // StartCoroutine(Hydraarray(0.5f, Infantry, way1));
        // Wordmatrix(Infantry);
        // StartCoroutine(ThousandArrows(0.5f, arrow));
       // strongArrows(StrongArrow);

    }
    public void stopbatte()
    {

        this.GetComponent<MyShoot>().enabled = false;
        // StartCoroutine(PlayerAttack());
       // StopCoroutine(PlayerAttack());

    }
    IEnumerator PlayerAttack()
    {
        while (isautos)
        {
            AIchooseSoldier(chooseAttackWay());
            yield return new WaitForSeconds(Random.Range(1.4f, 1.5f));
            // if ( isautos == true) {
            //StartCoroutine(PlayerAttack()); }
        }
       // Debug.Log("After 3s");
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
          if (BattleManager.getInstance().maulerNumber >= maulerNeed)
           {
                GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                //go.GetComponent<Infantry>().Food = InfantryFood;
                //go.GetComponent<ALLsoldiers>().Speed = 2;
               
                //GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(maulerFood, maulerNeed);
                go.transform.SetParent(way);
         }else
            {
               
                   // BattleManager.getInstance().Tip.text = "盾兵数量不足";
             
                AIchooseSoldier(chooseAttackWay());
            }
        }
        if (randomPoint > 21 && randomPoint <= 45)
        {
            if (BattleManager.getInstance().cavalryNumber >= cavalryNeed)
            {
                GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
              
               // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(cavalryFood, cavalryNeed);
                go.transform.SetParent(way);
           }
            else {
             //   BattleManager.getInstance().Tip.text = "骑兵数量不足";
                AIchooseSoldier(chooseAttackWay());
           }
        }
        if (randomPoint > 45 && randomPoint <= 72)
        {
               if (BattleManager.getInstance().ArcherNumber >= ArcherNeed)
                {
                    GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                   
                   // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(ArcherFood, ArcherNeed);
                    go.transform.SetParent(way);
                }
                else {
             //   BattleManager.getInstance().Tip.text = "弓兵数量不足";
                AIchooseSoldier(chooseAttackWay());
               // GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;

             
              //  go.transform.SetParent(way);

           }
        }
        if (randomPoint > 72 && randomPoint <= 100)
        {
               if (BattleManager.getInstance().InfantryNumber >=InfantryNeed)
               {
                    GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                  
                //    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(InfantryFood, InfantryNeed);
                    go.transform.SetParent(way);
              }
              else {
               // BattleManager.getInstance().Tip.text = "步兵数量不足";
                AIchooseSoldier(chooseAttackWay());

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
        else {
            return way1;

        }

    }
   
    public IEnumerator jiXinZhen(float time, GameObject soldiers)
    {
        for (int i = 0; i < 4; i++)
        {
            Transform way = chooseAttackWay();
            yield return new WaitForSeconds(time);
            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
        }
    }
    //一夫当关
    public void OneMan( GameObject soldiers)
    {
       
            Transform way = chooseAttackWay();

            GameObject soldier = Instantiate(soldiers, way.position, way.rotation) as GameObject;
        soldier.GetComponent<mauler>().setOneMan();
        
        soldier.transform.SetParent(way);
       
    }
   
    //万箭穿心

    IEnumerator ThousandArrows(float time, GameObject arrow)
    {
        for (int i = 0; i < 8; i++)
        {   Transform way= chooseAttackWay(); 
            yield return new WaitForSeconds(time);
            GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
            soldier.transform.SetParent(way);
        }

    }
    //百步穿杨
    public void strongArrows(GameObject arrow) {
        Transform way = chooseAttackWay();
        
        GameObject soldier = Instantiate(arrow, way.position, way.rotation) as GameObject;
        soldier.transform.SetParent(way);

    }
    //兵道按钮
    public void Onway1() {
       // _audioSource.PlayOneShot(xuanZheSound);
        ManualSoldiersShoot(way1);
    }


    public void Onway2() {
       // _audioSource.PlayOneShot(xuanZheSound);
        ManualSoldiersShoot(way2);
    }
    public void Onway3() {
       // _audioSource.PlayOneShot(xuanZheSound);
        ManualSoldiersShoot(way3);

    }
    
    public void Onway4()
    {
        //_audioSource.PlayOneShot(xuanZheSound);
        ManualSoldiersShoot(way4);

    }
    //按下疾行zhen
    public void OnJixinzhen()
    {
        if (BattleManager.getInstance().cavalryNumber >= cavalryNeed * 4)
        {
            StartCoroutine(jiXinZhen(0.7f, cavalry));
            StartCoroutine(skillButtonDaley());
        }
        else {
            BattleManager.getInstance().Tip.text = "骑兵数量不足";
        }
    }
    public void OnYizhizhen()
    {
        if (BattleManager.getInstance().maulerNumber>= maulerNeed )
        {
            OneMan(mauler);
            StartCoroutine(skillButtonDaley());
        }
        else
        {
            BattleManager.getInstance().Tip.text = "盾兵数量不足";
        }
    }

         public void OnBaibuchuanran()
    {

        strongArrows(StrongArrow);
        StartCoroutine(skillButtonDaley());
    }
    public void cilckBinZhongSound() {
        _audioSource.PlayOneShot(xuanZheSound);

    }

    //手动选择
    public void ManualSoldiersShoot(Transform way)
    {
        IEnumerable<Toggle> gg = ManualToggleSoldier.GetComponent<ToggleGroup>().ActiveToggles();
        //gg.GetType().
        foreach (Toggle ff in gg)
        {
            
            Debug.Log(ff.name);
            if (ff.name == "弓")
            {
                // GameObject go = Archer;
               if (BattleManager.getInstance().ArcherNumber >= ArcherNeed)
               {
                    GameObject go = Instantiate(Archer, way.position, way.rotation) as GameObject;
                    
                //    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(ArcherFood, ArcherNeed);
                    go.transform.SetParent(way);
                    //
                    //播放音效
                    _audioSource.PlayOneShot(gongBinSound[gongBinSoundSign]);
                    gongBinSoundSign++;
                    if (gongBinSoundSign == 3) {
                        gongBinSoundSign = 0;
                    }
                }
               else
                {
                    BattleManager.getInstance().Tip.text = "弓兵数量不足";
                }
            }
            if (ff.name == "盾")
            {
                if (BattleManager.getInstance().maulerNumber >= maulerNeed)
                {
                    GameObject go = Instantiate(mauler, way.position, way.rotation) as GameObject;
                   
                //    GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(maulerFood, maulerNeed);
                    go.transform.SetParent(way);
                    _audioSource.PlayOneShot(dunBinSound[dunBinSoundSign]);
                    dunBinSoundSign++;
                    if (dunBinSoundSign == 3)
                    {
                        dunBinSoundSign = 0;
                    }
                }
                else
                {
                    BattleManager.getInstance().Tip.text = "盾兵数量不足";
                }
            }
            if (ff.name == "步")
            {
                if (BattleManager.getInstance().InfantryNumber >=InfantryNeed)
                {
                    GameObject go = Instantiate(Infantry, way.position, way.rotation) as GameObject;
                   
                  //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(InfantryFood, InfantryNeed);
                    go.transform.SetParent(way);
                    _audioSource.PlayOneShot(buBinSound[buBinSoundSign]);
                    buBinSoundSign++;
                    if (buBinSoundSign == 3)
                    {
                        buBinSoundSign = 0;
                    }
                }
                else {

                    BattleManager.getInstance().Tip.text = "步兵数量不足";
                }
            }
            if (ff.name == "骑")
            {
                if (BattleManager.getInstance().cavalryNumber >= cavalryNeed)
                {
                    GameObject go = Instantiate(cavalry, way.position, way.rotation) as GameObject;
                   
                 //   GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().MYfooddamage(cavalryFood, cavalryNeed);
                    go.transform.SetParent(way);
                    _audioSource.PlayOneShot(qiBinSound[qiBinSoundSign]);
                    qiBinSoundSign++;
                    if (qiBinSoundSign == 3)
                    {
                        qiBinSoundSign = 0;
                    }
                }
                else
                {
                    BattleManager.getInstance().Tip.text = "骑兵数量不足";

                }
            }
           
        }
        //延时
        StartCoroutine(buttonDaley());
    }

    //按钮延时
    IEnumerator buttonDaley()
    {
        chooseWayButton.SetActive(false);
        yield return new WaitForSeconds(2);
        chooseWayButton.SetActive(true);
    }
    IEnumerator skillButtonDaley()
    {
        skillButton.SetActive(false);
        yield return new WaitForSeconds(10);
        skillButton.SetActive(true);
    }
    //播放手动音效
  /*  public void chooseSound(AudioClip[] Sound,int sign) {
        _audioSource.PlayOneShot(Sound[gongBinSoundSign]);
        gongBinSoundSign++;
        if (gongBinSoundSign == 3)
        {
            gongBinSoundSign = 0;
        }


    }*/
    public void gameover()
    {
        BattleManager.battleOver -= gameover;
        StopAllCoroutines();
    }
         
    void Awake()
    {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        _audioSource.volume = 1.0f;
        ms = this;
        //Screen.SetResolution(360,640,false);//设置分辨率

    }
    private static MyShoot ms;
    public static MyShoot getInstance()//不是内部变量
    {

        return ms;
           
    }
}
