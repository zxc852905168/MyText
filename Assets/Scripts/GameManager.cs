using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using AssemblyCSharp1;
using System.Xml.Linq;

using System.IO;

public class GameManager : MonoBehaviour
{
    private string _result;
    public PlayerDataJson playerData;
    public List<Prefecture> PlaceList = new List<Prefecture>();
    public GameObject ck;
    public GameObject gameScene;
    public string gameDataPath;
    public Text place;
    string allscores = "";
    private AudioSource _audioSource;
    
    //public EventStatus advanceStatus;
    // public ConceptStatus concept;

    void Start()
    {
      //cilckUi ck = cilckUi.getInstance();
   //  ck.GetComponent<cilckUi>().setAtice(true);
      //  cilckUi.getInstance().setAtice(true);
        gameDataPath = Application.persistentDataPath + "/GameData.json";
        // place.text = getPlace();
       //StartCoroutine(LoadXML());
        //StartCoroutine(AddressData1.GetXML());
    }
   // private void LoadXML(string path)
  //  {
       // _result =
       // "data source=" + Application.persistentDataPath +
        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml(_result);
   // }
 /* IEnumerator LoadXML()
    {
        string sPath;// = Application.streamingAssetsPath + "/String.xml"
        if (Application.platform == RuntimePlatform.Android)
        {
            sPath = Application.streamingAssetsPath + "/String.xml"; //在Android中实例化WWW不能在路径前面加"file://"
           // Debug.Log(localPath);
        }
        else
        {
            sPath = "file://" + UnityEngine.Application.streamingAssetsPath + "/String.xml";//在Windows中实例化WWW必须要在路径前面加"file://"

          //  Debug.Log(localPath);
        }
     ;
        WWW www = new WWW(sPath);
        //  WWW www = new WWW(localPath);
        while (!www.isDone)
        {
            yield return www;
            _result = www.text;
        }
    }*/
   /* void TEST() { //place.text = getPlace();
        foreach (int score in AddressData1.allScore)
        {
            allscores += score.ToString();
            place.text += "\t";
        }
        place.text = allscores;

    }*/
    /*void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 20;
        titleStyle.normal.textColor = new Color(46f / 256f, 163f / 256f, 256f / 256f, 256f / 256f);
        GUI.Label(new Rect(400, 10, 500, 200), _result, titleStyle);
    }*/

    //获取游戏时间
    public string getGameTime()
    {
        //string shi = gameData.time % 3 + "时";
        string day = playerData.time / 3 % 30 + 1 + readStringXMLData("day");
        string month = playerData.time / 3 / 30 % 12 + 1 + readStringXMLData("month") ;
        string year = playerData.time / 3 / 30 / 12 + readStringXMLData("year");
        return year + month + day;
    }
    //游戏时间变动
    public int increaseGameTime()
    {
        playerData.time++;
        MenuManager.getInstance().timeText.text = getGameTime();
        return playerData.time;
    }
    //游戏粮草变动
    public void foodUpdte()
    {
        playerData.liangCao-= playerData.armNumber / 10;
    }
    //游戏AI变动
    public void aiUpdte()
    {
        playerData.AiArms.AIsoldiers = 0.45f * playerData.time / 3 * (600 - playerData.time / 3);
        
        playerData.AiArms.AImonny = playerData.AiArms.AIsoldiers * 1.65f;
        playerData.AiArms.AIfood = playerData.AiArms.AIsoldiers * 1.35f;
    }
    //获取地点
    public string getPlace()
    {
        string fgf = "-";
        return readStringXMLData(playerData.place.dq.ToString())
            + fgf + readStringXMLData(playerData.place.j.ToString())
            + fgf + readStringXMLData(playerData.place.dd.ToString());
    }
    public void kuaJun()
    {
        jun dangQianJun = playerData.place.j;
        switch (dangQianJun)
        {
            case jun.minZhong:
                if (Random.Range(0, 2) == 0)
                {
                    playerData.place.j = jun.luJiang;
                }
                else
                {
                    playerData.place.j = jun.huiJi;
                }
                break;
            case jun.luJiang:

                break;
            case jun.huiJi: break;
        }
       
    }
    //行进逻辑
    public void xingJin()
    {
        // place.text = getPlace();
        //  LoadXML("String.xml");
        //TEST();
        MenuManager mm = MenuManager.getInstance();
      //  Debug.Log(readStringXMLData(playerData.place.dd.ToString()));
        mm.jinDuTiao.value += Random.Range(5, 11);
     //   Debug.Log(mm.jinDuTiao.value);
       // Debug.Log(readArmsXMLData("轻步兵", "Need"));
        if (mm.jinDuTiao.value >= 100)
        {

        }
        
        //数据更新
        place.text = getPlace();
       increaseGameTime();
         foodUpdte();
         aiUpdte();
        Highest();//最高分
        StopAllCoroutines();
       // EventManager ee = EventManager.getInstance();
        EventManager.getInstance().AdvanceEvent();
        // TEST();
        //EventManager.getInstance().AdvanceEvent();

       writeGameDataJsonData();
       // print(readGameDataJsonData());
    }

    //读取GameDataJson文件
    public string readGameDataJsonData()
    {
        return Func.getInstance().readJsonData(gameDataPath);
    }
    //写入GameDataJson文件
    public void writeGameDataJsonData()
    {
        Func.getInstance().writeJsonData(gameDataPath, playerData);
    }
    //读取String.xml文件的内容
    public string readStringXMLData(string itemName)
    {
       // print(_result);
       
        _result = Resources.Load("String").ToString();
             string fileName = _result;
        //TextAsset t = Resources.Load("Data/String.xml") as TextAsset;
        // strXml = Resources.Load("String.xml").ToString();
        // XmlDocument xmlChar = new XmlDoc();
        // xmlChar.LoadXml(strXml);
        //  XmlReader reader = XmlReader.Create(new StringReader(t.text));
        return Func.getInstance().readXMLData(fileName, itemName);
    }
    public string readArmsXMLData(string itemName, string value)
    {
       // string fileName = Application.streamingAssetsPath + "/Data/Arms.xml";
        string fileName = Resources.Load("Arms").ToString();
        return Func.getInstance().readXMLArmsData(fileName, itemName, value);
    }
   

   public int getMySoldiler()
    {
        return playerData.InfantryNumber + playerData.cavalryNumber + playerData.ArcherNumber + playerData.maulerNumber;

    }

    public void duQu() {
     playerData=  Func.LoadJsonFromFile(gameDataPath);

    }
    


    //地区
    public enum diQu
    {
        guanZhong,
        heNan,
        heBei,
        huaiHanYiNan,
        MAX
    }
    //地点
    public enum diDian
    {
        duCheng,
        junZhi,
        xianCheng,
        shanZhai,
        cunLou,
        yeWai,
        MAX
    }
    //郡
    public enum jun
    {
        minZhong,
        luJiang,
        huiJi,
        hengShan,
        changSha,
        zhang,
        dongHai,
        nan,
        qianZhong,
        jiuJiang,
        siChuan,
        hanZhong,
        ba,
        huaiYang,
        dang,
        nanYang,
        sanChuan,
        xianYang,
        MAX

    }
    
    //玩家属性对象
    [System.Serializable]
    public class PlayerDataJson
    {
        public int time;//游戏时间
        //兵种数量
       
        public int armNumber;
        public int InfantryNumber;
        public int cavalryNumber;
        public int ArcherNumber;
        public int maulerNumber;
        //兵种进阶名字
        public string InfantryName ;
        public string cavalryName ;
        public string ArcherName ;
        public string maulerName ;
        //兵种等级
        public int InfantryLV;
        public int cavalryLV;
        public int ArcherLV;
        public int maulerLV;
        public int[,,] army;//军队
        public int liangCao;//粮草
        public int minXin;
        public int money;//钱币
        public int lianBinXingde;//练兵心得
        public int qiangHuXingde;//练兵心得
        public int xunLianXingde;//练兵心得
        public int yiZhiZhen;//一字zhen
        public int jiXinZhen;//一字zhen
        public int baiBuZhen;//一字zhen
        //最大值
        public int HighestSoldiers;
        public int HighestmMinXin;
        public int HighestFood;
        public int HighestMonny;
        public Prefecture place;//位置
        public PrefectureAiArms AiArms;
    }
    //地点属性对象
    [System.Serializable]
    public class Prefecture
    {

        public diQu dq;//地区

        public diDian dd;//地点

        public jun j;//郡

        //public Prefecture(diQu dq,jun j)
        //{
        //    this.dq = dq;
        //    this.j = j;
        //}
    }
  
    public class PrefectureModel
    {
        public List<Prefecture> preList;
    }
    [System.Serializable]
    public class PrefectureAiArms
    {
        // playerData.time
        public float AIsoldiers ;
        
        public float AImonny ;
        public float AIfood;
          //事件敌人数据  
        public float placeSoldiers;
        public float placeMonny ;
        public float placeFood;
        //敌人兵种
        public string InfantryName;
        public string cavalryName;
        public string ArcherName;
        public string maulerName;
    }
    //最高分替换
    public void Highest()
    {
        if (playerData. HighestSoldiers < getMySoldiler())
        {
            playerData.HighestSoldiers = getMySoldiler();
            
        }
        if (playerData.HighestMonny < playerData.money)
        {
            playerData.HighestMonny = playerData.money;
            
        }
        if (playerData.HighestFood< playerData.liangCao)
        {
            playerData.HighestFood = playerData.liangCao;
            
        }
        if (playerData.HighestmMinXin < playerData.minXin)
        {
            playerData.HighestmMinXin =playerData.minXin;
            //PlayerPrefs.SetFloat("Highestreputation", reputation);
        }
   

    }
    public void pauseSound()
    {
        gameScene.gameObject.GetComponent<AudioSource>().Stop();

    }
    public void playSound()
    {
        gameScene.gameObject.GetComponent<AudioSource>().Play();

    }
    void Awake()
    {
        _audioSource = gameScene.gameObject.AddComponent<AudioSource>();
        gm = this;
        //Screen.SetResolution(360,640,false);//设置分辨率

    }
   
    private static GameManager gm;
    public static GameManager getInstance()
    {
        
        return gm;
    }
}