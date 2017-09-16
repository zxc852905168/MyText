using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum EventStatus
    {
        None,
        Poison,
        Slow,
        Mute,
        junZhi,
        xianChen,
        sanZhai,
        cunLuo,
        liangCaoShang,
        nuLiShang,
        yiBinGanRan,
       qiYiJun,
       guanBin
        /*
        郡治,
        县城,
        山寨,
        村落,
        粮草商,
        奴隶商,
        疫病感染,
        起义军,
        无*/
    }
    //状态
    public enum ConceptStatus
    {
        zhanDou,
        cunLuo,
        jiaoYi,
        jiaoYiZhong,
    None
    /*
    无事件,
    战斗,
    裁军,
    村落,
    交易,
    交易中*/
}
public class EventManager : MonoBehaviour {
    public EventStatus advanceStatus;
    public ConceptStatus concept;
    public int theMax;
    private AudioSource _audioSource;
    public AudioClip zhanBai;//战败音效
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    //  public void changePlaceSoldiers(float min ,float max,float gain) {



    //}
    //行进事件
    public void AdvanceEvent()
    {
        MenuManager mm = MenuManager.getInstance();
        GameManager gg = GameManager.getInstance();
        // mm.chooseUI();
        // print("ff"); 
        float gain = 0;
        //随机事件
        float randomPoint = Random.value * 100;
         print(randomPoint);
        if (randomPoint <= 2.5)
        {//郡治
            advanceStatus = EventStatus.junZhi;
            concept = ConceptStatus.zhanDou;
            //改变地方数据
            gg.playerData.AiArms.placeSoldiers = (Random.Range(0.5f, 0.6f) + gain) * GameManager.getInstance().playerData.AiArms.AIsoldiers;
            gg.playerData.AiArms.placeMonny = (Random.Range(0.5f, 0.6f) + gain) * GameManager.getInstance().playerData.AiArms.AImonny;
            gg.playerData.AiArms.placeFood = (Random.Range(0.55f, 0.65f) + gain) * GameManager.getInstance().playerData.AiArms.AIfood;
            //ui控制
            MenuManager.getInstance().chooseUI();

        }
        //县城
        if (randomPoint > 2.5 && randomPoint <= 15)
        {
            advanceStatus = EventStatus.xianChen;
            concept = ConceptStatus.zhanDou;
            gg.playerData.AiArms.placeSoldiers = (Random.Range(0.4f, 0.5f) + gain) * gg.playerData.AiArms.AIsoldiers;
            gg.playerData.AiArms.placeMonny = (Random.Range(0.4f, 0.5f) + gain) * gg.playerData.AiArms.AImonny;
            gg.playerData.AiArms.placeFood = (Random.Range(0.45f, 0.55f) + gain) * gg.playerData.AiArms.AIfood;
            MenuManager.getInstance().chooseUI();
        }
        //山寨
        if (randomPoint > 15 && randomPoint <= 35)
        {
            //
            advanceStatus = EventStatus.sanZhai;
            concept = ConceptStatus.zhanDou;
            gg.playerData.AiArms.placeSoldiers = (Random.Range(0.3f, 0.4f) + gain) * gg.playerData.AiArms.AIsoldiers;
            gg.playerData.AiArms.placeMonny = (Random.Range(0.3f, 0.4f) + gain) * gg.playerData.AiArms.AImonny;
            gg.playerData.AiArms.placeFood = (Random.Range(0.35f, 0.45f) + gain) * gg.playerData.AiArms.AIfood;
            MenuManager.getInstance().chooseUI();
        }
        //村落
        if (randomPoint > 35 && randomPoint <= 47.5)
        {
            advanceStatus = EventStatus.cunLuo;
            concept = ConceptStatus.cunLuo;
            gg.playerData.AiArms.placeSoldiers = (Random.Range(0.4f, 0.5f) + gain) * gg.playerData.AiArms.AIsoldiers;
            gg.playerData.AiArms.placeMonny = (Random.Range(0.4f, 0.5f) + gain) * gg.playerData.AiArms.AImonny;
            gg.playerData.AiArms.placeFood = (Random.Range(0.45f, 0.55f) + gain) * gg.playerData.AiArms.AIfood;
            MenuManager.getInstance().chooseUI();
        }
        //奴隶商
        if (randomPoint > 47.5 && randomPoint <= 53.75)
        {
            advanceStatus = EventStatus.nuLiShang;
            concept = ConceptStatus.jiaoYi;
            readyTransactionEvent();
        }
        if (randomPoint > 53.75 && randomPoint <= 60)
        {
            advanceStatus = EventStatus.liangCaoShang;
            concept = ConceptStatus.jiaoYi;
            readyTransactionEvent();
        }
        if (randomPoint > 60 && randomPoint <= 65)
        {
            advanceStatus = EventStatus.yiBinGanRan;
            concept = ConceptStatus.None;
            diseaseEvent(); 
        }
        if (randomPoint > 65)
        {
            advanceStatus = EventStatus.None;
            concept = ConceptStatus.None;
            MenuManager.getInstance().eventZhezhao();
        }

    }

    //战斗事件
    public void battleEvent()
    {
        BattleManager.getInstance().battleStart();

    }
    //战斗结束事件
    //战胜事件
    public void winEvent() {
      //  MenuManager.getInstance().winUI();//写成参函数
        winAward();
        //  BattleManager.getInstance().battleOver();
    }
    // 战败事件
    public void failEvent() {
        MenuManager.getInstance().failUI();
        failPunishment();
    }
    //撤退事件
    public void Evacuate()
    {

    }
    //战胜奖励
    public void winAward() {
        GameManager gg = GameManager.getInstance();
        int apm = (int)(1.32 * gg.playerData.AiArms.placeMonny);
        int aps = (int)(0.7 * gg.playerData.AiArms.placeSoldiers);
        int apf = (int)(1.1 * gg.playerData.AiArms.placeFood + gg.playerData.minXin * 30);
        int mx = Random.Range(1,3);
      
        gg.playerData.money += (int)(1.32 * gg.playerData.AiArms.placeMonny);
        gg.playerData.InfantryNumber += (int)(0.7* gg.playerData.AiArms.placeSoldiers);
        gg.playerData.liangCao += (int)(1.1 * gg.playerData.AiArms.placeFood + gg.playerData.minXin * 30);
        gg.playerData.minXin += mx;
        //破城事件
        if (advanceStatus == EventStatus.xianChen || advanceStatus == EventStatus.junZhi)
        {
            float randomPoint = Random.value * 100;
            //  print(randomPoint);
            if (randomPoint <= 30)
            {//商队事件
             //CaravanEvent();
                MenuManager.getInstance().winUI("", aps, apm, apf, mx);
            }

                if (randomPoint > 30 && randomPoint <= 38)
                {
                    GameManager.getInstance().playerData.qiangHuXingde += 1;
                    MenuManager.getInstance().winUI("获得强化心得", aps, apm, apf, mx);
                }
                if (randomPoint > 38 && randomPoint <= 44)
                {
                    GameManager.getInstance().playerData.xunLianXingde += 1;
                    MenuManager.getInstance().winUI("获得训练心得", aps, apm, apf, mx);
                }
                if (randomPoint > 44 && randomPoint <= 48)
                {
                    GameManager.getInstance().playerData.lianBinXingde += 1;
                    MenuManager.getInstance().winUI("获得练兵心得", aps, apm, apf, mx);
                }
                if (randomPoint > 48 && randomPoint <= 52)
                {
                    GameManager.getInstance().playerData.lianBinXingde += 1;
                    MenuManager.getInstance().winUI("获得练兵心得", aps, apm, apf, mx);
                }
                if (randomPoint > 52 && randomPoint <= 57)
                {
                    GameManager.getInstance().playerData.yiZhiZhen += 1;
                    MenuManager.getInstance().winUI("获得练兵心得", aps, apm, apf, mx);
                }
                if (randomPoint > 61.5 && randomPoint <= 65.5)
                {
                    GameManager.getInstance().playerData.jiXinZhen += 1;
                    MenuManager.getInstance().winUI("获得阵技残卷-疾行阵", aps, apm, apf, mx);
                }
                if (randomPoint > 65.5 && randomPoint <= 69.5)
                {
                    GameManager.getInstance().playerData.baiBuZhen += 1;
                    MenuManager.getInstance().winUI("获得阵技残卷-一字阵", aps, apm, apf, mx);
                }
                if (randomPoint > 69.5 && randomPoint <= 100)
                {
                    MenuManager.getInstance().winUI("获得阵技残卷-百步穿杨", aps, apm, apf, mx);
                }

            }
            else
            {

                MenuManager.getInstance().winUI("", aps, apm, apf, mx);
            }
        
        }

    //战败惩罚
    public void failPunishment()
    {
     GameManager.getInstance().playerData.minXin += 1;
        MenuManager.getInstance().failUI();
        _audioSource.PlayOneShot(zhanBai);
    }
    //入村事件
    public void villageEvent()
    {
        float randomPoint = Random.value * 100;
        //  print(randomPoint);
        if (randomPoint <= 30) {
            villageBattle();


        } else {
            villageAward();


        }
    }
    //入村奖励
    public void villageAward()
    {
        GameManager gg = GameManager.getInstance();
        int apm = (int)(gg.playerData.AiArms.placeMonny * Random.Range(0.5F, 0.6F));
        int aps = (int)((Random.Range(0.4F, 0.5F)) * gg.playerData.AiArms.placeSoldiers);
        int apf = (int)( gg.playerData.AiArms.placeFood * Random.Range(0.45F, 0.55F));
        gg.playerData.money += (int)(Random.Range(0.5f, 0.6f) * gg.playerData.AiArms.placeMonny);
        gg.playerData.InfantryNumber += (int)(Random.Range(0.4f, 0.5f)*gg.playerData.AiArms.placeSoldiers);
        gg.playerData.liangCao+= (int)(Random.Range(0.45f, 0.55f) * gg.playerData.AiArms.placeFood + gg.playerData.minXin * 30);
        MenuManager.getInstance().eventZhezhaoCunLuo(aps, apm, apf);
        MenuManager.getInstance().NoButtonUp();
    }

    //入村起义军
    public void villageBattle()

    {
        //MenuManager mm = MenuManager.getInstance();
        advanceStatus = EventStatus.qiYiJun;
        concept = ConceptStatus.zhanDou;
        MenuManager.getInstance().chooseBattleUI();
       
    }
    //破城事件
    public void BreakCity() {

    }
    //商队事件
    public void CaravanEvent() {

        MenuManager mm = MenuManager.getInstance();
        GameManager gg = GameManager.getInstance();
        // mm.chooseUI();
        // print("ff"); 
        float gain = 0;
        //随机事件
        float randomPoint = Random.value * 100;
        if (randomPoint > 0 && randomPoint <= 50)
        {
            advanceStatus = EventStatus.nuLiShang;
            concept = ConceptStatus.jiaoYi;
           
            mm.chooseUI();
            Tips.getInstance().setText("见到了奴隶商人，想交易吗");
        }
        if (randomPoint > 50 && randomPoint <= 100)
        {
            advanceStatus = EventStatus.liangCaoShang;
            concept = ConceptStatus.jiaoYi;
           
            mm.chooseUI();
            Tips.getInstance().setText("见到了粮草商人，想交易吗");
        }
    }
    //准备交易中事件
    public void readyTransactionEvent()
    {
       
        int min = 1000;
        int zhengjia;
        int max;

             if (EventManager.getInstance().advanceStatus == EventStatus.liangCaoShang)
        {
            zhengjia = (int)( GameManager.getInstance().playerData.HighestFood * 1.1);
            max = min + zhengjia;
            if (max > 2000)
            {
                max = 2000;

            }
            // transactionFood = even;
            //  MenuManager.getInstance().transactionUi(0, max);
            theMax = max;
            MenuManager.getInstance().chooseTransactionText(max);
        }
        if (EventManager.getInstance().advanceStatus == EventStatus.nuLiShang)
        {
            zhengjia = (int)(GameManager.getInstance().playerData.HighestSoldiers* 1.25);
            max = min + zhengjia;
            if (max > 2000)
            {
                max = 2000;

            }
            theMax = max;
            MenuManager.getInstance().chooseTransactionText(max);
        }

       
    }
    public void yesTransactionEvent()
    {
        concept = ConceptStatus.jiaoYiZhong;
        MenuManager.getInstance().transactionUi(0, theMax);
    }
    //确定交易事件
    public void firmTransactionEvent()
    {
        int theMonny = GameManager.getInstance().playerData.money;
        if (theMonny - (int)MenuManager.getInstance().transactionMonny >= 0)
        {
            GameManager.getInstance().playerData.money -= (int)MenuManager.getInstance().transactionSoldiler;
            if (EventManager.getInstance().advanceStatus == EventStatus.liangCaoShang)
            {

                GameManager.getInstance().playerData.liangCao += (int)MenuManager.getInstance().transactionFood;
                MenuManager.getInstance().transactionSuccess();
            }
            if (EventManager.getInstance().advanceStatus == EventStatus.nuLiShang)
            {
                GameManager.getInstance().playerData.InfantryNumber += (int)MenuManager.getInstance().transactionSoldiler;

                MenuManager.getInstance().transactionSuccess();
            }
        }
        else {
            MenuManager.getInstance().TextNoMonny();

        }
    }

    //疫病事件
    public void diseaseEvent() {
       float jiansao = GameManager.getInstance().playerData.InfantryNumber * Random.Range(0.1f,0.12f);
        GameManager.getInstance().playerData.InfantryNumber -= (int)jiansao;
        MenuManager.getInstance().eventZhezhaoYiBin((int)jiansao) ;
    }
    void Awake()
    {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        em = this;
        

    }
    private static EventManager em;
    public static EventManager getInstance()
    {

        return em;
    }
}
