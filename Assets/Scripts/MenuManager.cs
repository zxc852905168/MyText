using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{

    public GameObject MenuScene;//菜单
    public GameObject GameScene;//游戏
    public GameObject BattleScene;//游戏
    public GameObject cilcktext;
    public GameObject zhehaotext;
    public GameObject XingJinMap;//行进地图
    //public GameObject mainButton;//游戏
   // public GameObject YesOrNoButton;//游戏
   // public GameObject battleButton;//行进地图
   public Button[] mainButton;//主按钮
    public Button[] YesOrNoButton;//是否按钮
    public Button[] battleButton;
    public Animator LaDong;//信息栏拉动
    public Animator XinXi2;//信息栏2
    public Animator ChooseButton;//选择按钮
    public Text timeText;//时间显示文本
    public Text PromptText;
    public Text renKouText;//时间显示文本
    public Text minXinText;
    public Text liangCaoText;
    public Text monnyText;
    public Slider jinDuTiao;//进度条
    public GameObject transactionTiao;//交易条
    public GameObject tiaoBingJieMian;
    public float transactionFood;
    public float transactionSoldiler;
    public float transactionMonny;
    //记录鼠标点击位置
    private Vector3 v0;
    void Awake()
    {
        menuManager = this;
    }
    // Use this for initialization
    void Start()
    {
        MenuScene.SetActive(true);
        GameScene.SetActive(false);
        XingJinMap.SetActive(false);

       //要的 timeText.text = GameManager.getInstance().getGameTime();
    }

    // Update is called once per frame
    void Update()
    {


    }
    //新游戏按钮事件
    public void newGameButton()
    {
        //GameManager.getInstance().
       MenuScene.SetActive(false);
        GameScene.SetActive(true);
        xinJinText();
    }
    //加载游戏按钮事件
    public void loadGameButton()
    {
        GameManager.getInstance().duQu();
        MenuScene.SetActive(false);
        GameScene.SetActive(true);
        //Func.getInstance().readData();
        xinJinText();
    }
    //最好战绩按钮事件
    public void bastAchievement()
    {

    }

    //拖动事件
    public void dragButton()
    {
        //MenuScene.SetActive(true);
        //GameScene.SetActive(false);
        //Debug.Log("mouse:" + MousePosition + ";; input:" + Input.mousePosition);
        //if (Input.mousePosition.y < MousePosition.y)
        //{
        //    LaDong.SetTrigger("Down");
        //}
        //else
        //{
        //    LaDong.SetTrigger("Up");
        //}

        //Debug.Log("拖动");
    }
    public void clickButton()
    {

        LaDong.SetBool("IsUp", !LaDong.GetBool("IsUp"));
        XinXi2.SetBool("IsUp", !XinXi2.GetBool("IsUp"));
        //MousePosition = Input.mousePosition;
        //Debug.Log("点击：" + MousePosition);

    }
    //数据表文本
    public void xinJinText() {
        renKouText.text=GameManager.getInstance().playerData.armNumber.ToString();//时间显示文本
     minXinText.text = GameManager.getInstance().playerData.minXin.ToString(); ;
    liangCaoText.text = GameManager.getInstance().playerData.liangCao.ToString(); ;
     monnyText.text = GameManager.getInstance().playerData.money.ToString(); ;
}
    //事件text显示
    public void eventText(string str) {
        cilckUi.getInstance().setAtice(true);
        cilckUi.getInstance().setText(str);
    }
    //点击行进按钮
    public void clickXingJin()
    {
        //ChooseButton.SetBool("IsUp", false);
        PromptText.text = " ";
        xinJinText();
        GameManager.getInstance().xingJin();
    }
    //选择事件ui
    public void chooseUI() {
        YesOrNoButtonUp();//
        chooseText();
       /// print("v");
    }
    //选择是否进攻界面ui
    public void chooseBattleUI()
    {
        battleButtonUp();
        chooseBattleText();


    }

    //交易界面ui
    //
    //是否按钮上升
    public void YesOrNoButtonUp()
    {
        foreach (Button theButton in YesOrNoButton)
        {
            theButton.transform.DOMoveY(450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
       foreach (Button theButton in mainButton)
        {
            theButton.transform.DOMoveY(-450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
    }
    //进攻按钮上升
    
    public void battleButtonUp()
    {
        foreach (Button theButton in YesOrNoButton)
        {
            theButton.transform.DOMoveY(-450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);
//
       }
        foreach (Button theButton in battleButton)
        {
            theButton.transform.DOMoveY(450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
    }
    public void mainButtonUp()
    {
        foreach (Button theButton in mainButton)
        {
            theButton.transform.DOMoveY(450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);
            //
        }
        foreach (Button theButton in battleButton)
        {
            theButton.transform.DOMoveY(-450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
    }
    public void NoButtonUp()
    {
        foreach (Button theButton in mainButton)
        {
            theButton.transform.DOMoveY(450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);
            //
        }
        foreach (Button theButton in YesOrNoButton)
        {
            theButton.transform.DOMoveY(-450, 0.5f).SetEase(Ease.OutBack).SetRelative();
            // go.transform.DOLocalMoveY(-1000, 1f, false).From().SetEase(Ease.OutBack);

        }
    }
    //限制函数
    //是按钮
    public void OnYes()
    {
        string text;
        float ps;
        float pm;
        float pf;
        //if (EventManager.getInstance().concept == ConceptStatus.裁军)
        //{

        ;
        //}
        if (EventManager.getInstance().concept == ConceptStatus.zhanDou)
        {

            chooseBattleUI();

        }
        if (EventManager.getInstance().concept == ConceptStatus.cunLuo)
        {
            EventManager.getInstance().villageEvent();
            
        }
        //交易中
        if (EventManager.getInstance().concept == ConceptStatus.jiaoYiZhong)
        {
            // transactionEvent();
            EventManager.getInstance().firmTransactionEvent();


        }
        //交易
        if (EventManager.getInstance().concept == ConceptStatus.jiaoYi)
        {
            EventManager.getInstance().yesTransactionEvent();

        }


       
    }
    //否按钮
    public void OnNo()
    {
        NoButtonUp();
        Tips.getInstance().setText("接下来该怎么做呢？");
        transactionTiao.SetActive(false);

    }
    //进攻按钮
    public void OnBattle()
    {
        BattleScene.SetActive(true);
        EventManager.getInstance().battleEvent();
      mainButtonUp();
    }
    //撤退按钮
    public void OnEvacuate()
    {
        Tips.getInstance().setText("接下来该怎么做呢？");
        mainButtonUp();
    }
    //返回按钮
    public void OnReturn()
    {

    }
    //减少按钮
    public void OnReduce()
    {

    }
    //增加按钮
    public void OnIncrease()
    {

    }
    public void OnTiaoBing() {
        tiaoBingJieMian.SetActive(true);
        tiaobin.getInstance().changeText();
    }
    //进阶按钮

    //行进地图的返回按钮
    public void xingJinMapFanHui()
    {
        XingJinMap.SetActive(false);
    }
    //选择事件文本
    public void chooseText()
    {
        string text;
        string place="";
        float ps;
        float xx=0;
        float xb = 0;
        float pm;
        float pf;
        //山寨是否进攻文本
        if (EventManager.getInstance().advanceStatus == EventStatus.sanZhai)
        {

            text = "抵达山寨\n你来到了本郡某山寨" + place + "附近" + "\n是否要率军攻打该山寨？";
            Tips.getInstance().setText(text);
        }
        //郡治是否进攻文本
        if (EventManager.getInstance().advanceStatus == EventStatus.junZhi)
        {

            text = "抵达郡治\n你来到了本郡郡治" + place + "附近" + "\n是否要率军攻打该郡治？";
            Tips.getInstance().setText(text);
        }

        if (EventManager.getInstance().advanceStatus == EventStatus.xianChen)
        {

            text = "抵达县城\n你来到了本郡的县城" + place + "附近" + "\n是否要率军攻打该县城";
            Tips.getInstance().setText(text);
        }


        if (EventManager.getInstance().advanceStatus == EventStatus.cunLuo)
        {

            text = "抵达村落\n你来到了本郡的某村落附近，是否要率军入驻该村落？";
            Tips.getInstance().setText(text);

        }


         
           
           

        
    }
    public void chooseBattleText() {

        string text;
        string place = "";
        int ps= (int)GameManager.getInstance().playerData.AiArms.placeSoldiers; 
        
        int pm = (int)GameManager.getInstance().playerData.AiArms.placeMonny; 
        int pf = (int)GameManager.getInstance().playerData.AiArms.placeFood; 
        //山寨是否进攻文本
        if (EventManager.getInstance().advanceStatus == EventStatus.sanZhai)
        {

            text = "   " + place +"山寨"+ "\n士兵：" + ps.ToString() + "\n粮草：" + pf.ToString()
                             + "\n钱币：" + pm.ToString();
            Tips.getInstance().setText(text);
        }
        //郡治是否进攻文本
        if (EventManager.getInstance().advanceStatus == EventStatus.junZhi)
        {

            text = "   " + place + "郡治" + "\n士兵：" + ps.ToString() + "\n粮草：" + pf.ToString()
                              + "\n钱币：" + pm.ToString();
            Tips.getInstance().setText(text);
        }

        if (EventManager.getInstance().advanceStatus == EventStatus.xianChen)
        {

            text = "   " + place + "县城" + "\n士兵：" + ((int)ps).ToString() + "\n粮草：" + pf.ToString()
                              + "\n钱币：" + pm.ToString();
            Tips.getInstance().setText(text);
        }

        if (EventManager.getInstance().advanceStatus == EventStatus.qiYiJun)
        {

            text = "   " + place + "起义军" + "\n士兵：" + ps.ToString() + "\n粮草：" + pf.ToString()
                             + "\n钱币：" + pm.ToString();
            Tips.getInstance().setText(text);

        }
    }
    public void winUI(string jinen,int aps, int apm,int apf,int mx)
    {
        string text;
       
        text = "【战胜】恭喜你此次作战获得了最终的胜利\n你的实力再次壮大了\n民心也因此有所提升【\n士兵 + " + (int)aps + "、粮草 +" + (int)apm + "\n钱币 +" + (int)apf + "、民心 + " + (int)mx+ jinen+"】";
        eventTextzhezhao(text);
        // cilckUi.getInstance().setAtice(true);
        //cilckUi.getInstance().setText(text);
        //  Destroy(BattleScene.gameObject);
    }
    public void failUI()
    {
        BattleScene.SetActive(false);
        string text;

        text = "【战败】很可惜，此次作战你失败了，不过民心依旧提升了一点【民心+1】";
        eventTextzhezhao(text);
        // Destroy(BattleScene.gameObject);
    }
    //发生遮罩事件
    public void eventZhezhao()
    {
        string text;
      //  int xb = 0;
       


        if (EventManager.getInstance().advanceStatus == EventStatus.None)
        {

            text = "     无事件\n行进了几个时辰之后\n斥候也没在附近发现有人口聚集之地";
            eventTextzhezhao(text);

        }
       // if (EventManager.getInstance().advanceStatus == EventStatus.cunLuo)
       // {

           // text = "\n村民们听闻是你公子扶苏的起义军队后，\n热情地将你率军队在村中休整一番\n并且不少青壮申请加入你的队列\n还献来了一些钱粮\n【士兵 + " + (int)GETplaceSoldiers + "、粮草 +" + (int)GETplacemonny + "\n钱币 +" + (int)GETplacefoodstuff + "】";
            //eventTextzhezhao(text);

       // }

    }
    public void eventZhezhaoYiBin(int xb) {
        string text;
        if (EventManager.getInstance().advanceStatus == EventStatus.yiBinGanRan)
        {
            text = "疫病感染\n流感突发\n不少士兵因此病逝了【士兵-" + xb + "】";
            eventTextzhezhao(text);


        }
    }
    public void eventZhezhaoCunLuo(int aps, int apm, int apf)
    {
        string text;
        text = "\n村民们听闻是你公子扶苏的起义军队后，\n热情地将你率军队在村中休整一番\n并且不少青壮申请加入你的队列\n还献来了一些钱粮\n【士兵 + " + (int)aps+ "、粮草 +" + (int)apm+ "\n钱币 +" + (int)apf + "】";
        eventTextzhezhao(text);
    }
    //发生遮罩事件文本
    public void eventTextzhezhao(string str) {

        BattleScene.SetActive(false);
        zhehaotext.GetComponent<zhezhao>().setAtice(true);
        cilcktext.GetComponent<cilckUi>().setText(str);

    }
    //进攻准备事件文本
    public void battleReadyText()
    {
        if (EventManager.getInstance().advanceStatus == EventStatus.sanZhai)
        {


        }
        //郡治数据文本
        if (EventManager.getInstance().advanceStatus == EventStatus.junZhi)
        {


        }

        if (EventManager.getInstance().advanceStatus == EventStatus.xianChen)
        {


        }
        //起义军数据文本
        if (EventManager.getInstance().advanceStatus == EventStatus.qiYiJun)
        {


        }
    }
    public void chooseTransactionText(int xx) {
        string text;
        YesOrNoButtonUp();

        if (EventManager.getInstance().advanceStatus == EventStatus.nuLiShang)
        {

            text = "商队交易\n支奴隶商队\n携带着人口" + xx + "来到了附近\n是否与之交易？";
            Tips.getInstance().setText(text);
        }


        if (EventManager.getInstance().advanceStatus == EventStatus.liangCaoShang)
        {

            text = "商队交易\n支粮草商队\n携带着粮草" + xx + "来到了附近\n是否与之交易？";
            Tips.getInstance().setText(text);

        }
    }
    //交易事件ui
    public void transactionUi(int min,int max)
    {
        transactionTiao.GetComponent<Slider>().value = 0;
        transactionTiao.SetActive(true);
        transactionTiao.GetComponent<Slider>().maxValue = max;
        transactionTiao.GetComponent<Slider>().minValue= min;
        //string text;
        // text = "
       string text = "    【是否确认完成购买】" + "\n购买：" + 0 + " 总价：" + 0;
       Tips.getInstance().setText(text);

    }
    public void transactionSliderevent(float even)
    {



       // transactionText(even);//滑动条事件


    }
    //交易事件文本
    public void transactionText() {
        float even = transactionTiao.GetComponent<Slider>().value;
        PromptText.text = "";
        string text;
        print("aaa");
        if (EventManager.getInstance().advanceStatus == EventStatus.liangCaoShang)
        {
          text = "    【是否确认完成购买】" + "\n购买：" + (int)even + " 总价：" + (int)even * 2.5f;
        Tips.getInstance().setText(text);

     transactionFood = even;
        transactionMonny= (int)even * 2.5f;
}
        if (EventManager.getInstance().advanceStatus == EventStatus.nuLiShang)
        {
            text= "    【是否确认完成购买】" + "\n购买：" + (int)even + " 总价：" + (int)even * 3;
            Tips.getInstance().setText(text);
transactionSoldiler = even;
    transactionMonny=(int)even* 3;
        }

    }
    //交易不成功
    public void TextNoMonny()
    {
        PromptText.text = "   钱不够";
    }
    //交易成功
    public void transactionSuccess()
    {
        NoButtonUp();
        string text;
       text = "交易成功";
        Tips.getInstance().setText(text);
        transactionTiao.SetActive(false);
    }
    //地图事件
    public void ditu(int index)
    {
        
        Vector3 v1;
        if(index == 0){
            v0 = Input.mousePosition;
        }
        else
        {
            v1 = Input.mousePosition;
            if (v0.y > v1.y)
            {
                Debug.Log("向下");
            }
            if (v0.y < v1.y)
            {
                Debug.Log("向上");
            }
            //if (v0.x> v1.x)
            //{
            //    Debug.Log("向左");
            //}
            //if (v0.x< v1.x)
            //{
            //    Debug.Log("向右");
            //}
        }
        
        
    }



    public static MenuManager menuManager;
    public static MenuManager getInstance()
    {
        return menuManager;
    }
    private MenuManager()
    {
    }

}