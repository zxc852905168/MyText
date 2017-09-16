using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tiaobin : MonoBehaviour {
    public string InfantryNumberstr;
    public string cavalryNumberstr;
    public string ArcherNumberstr;
    public string maulerNumberstr;
    public string jinJieMingZhi;
    public string biaoJi;
    public string biaoJiName;
    public InputField Infantryin;
    public InputField Archerin;
    public InputField cavalryin;
    public InputField maulerin;
    public Text monnytext;
    public Text jinJieText;
    public Text aName;
    public Text aNum;
    public Text cName;
    public Text cNum;
    public Text iName;
    public Text iNum;
    public Text mName;
    public Text mNum;
    public GameObject jinJiechen;
    public GameObject tiaobinchen;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string readArmsXMLData(string itemName, string value)
    {
        //string fileName = Application.dataPath + "/Data/Arms.xml";
        string fileName = Resources.Load("Arms").ToString();
        return Func.getInstance().readXMLArmsData(fileName, itemName, value);
    }
    public string getChineseName(string name) {

        return readArmsXMLData(name, "name");
    }
    //改变士兵数据文本
    public void changeText(){
        aName.text=getChineseName(GameManager.getInstance().playerData.ArcherName);
     aNum.text ="数量："+ GameManager.getInstance().playerData.ArcherNumber.ToString();
        cName.text = getChineseName(GameManager.getInstance().playerData.cavalryName); ;
        cNum.text = "数量：" + GameManager.getInstance().playerData.cavalryNumber.ToString();
        iName.text = getChineseName(GameManager.getInstance().playerData.InfantryName); ;
        iNum.text = "数量：" + GameManager.getInstance().playerData.InfantryNumber.ToString();
        mName.text = getChineseName(GameManager.getInstance().playerData.maulerName); ;
        mNum.text = "数量：" + GameManager.getInstance().playerData.maulerNumber.ToString();

    }
    public void Infantryadd()
    {
        float InfantryNumber;
        float monny;
        InfantryNumberstr = Infantryin.textComponent.text;
        if (isnumeric(InfantryNumberstr))
        {
            InfantryNumber = int.Parse(InfantryNumberstr);
            monny = InfantryNumber * 3;
            print(InfantryNumber);
          
            if (GameManager.getInstance().playerData.money< monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                // monny = PlayerPrefs.GetFloat("monny") - monny1;
                // PlayerPrefs.SetFloat("monny", monny);
                GameManager.getInstance().playerData.InfantryNumber += (int)InfantryNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "征召成功";
            }

        }
        else
        {
            Infantryin.textComponent.text="请输入数字";

        }

    }
    //步兵减
    public void Infantryreduce()
    {
        float InfantryNumber;
        float monny;
        InfantryNumberstr = Infantryin.textComponent.text;
        if (isnumeric(InfantryNumberstr))
        {
            InfantryNumber = int.Parse(InfantryNumberstr);
            monny = InfantryNumber * 4;
           // print(InfantryNumber1);
            //InfantryNumber = PlayerPrefs.GetFloat("InfantryNum") - InfantryNumber1;
           // PlayerPrefs.SetFloat("InfantryNum", InfantryNumber);
           // monny = PlayerPrefs.GetFloat("monny");
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.InfantryNumber -= (int)InfantryNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "裁军成功";
            }

        }
        else
        {
           Infantryin.textComponent.text="请输入数字";

        }
    }
    //步兵输入结束
    public void Infantrytext(string str)
    {
        int InfantryNumber1;
        // print(str);
        InfantryNumberstr = Infantryin.textComponent.text;
        //float monny1;
        if (InfantryNumberstr != null)
        {
            if (isnumeric(InfantryNumberstr))
            {
                int.TryParse(InfantryNumberstr, out InfantryNumber1);
                //   print(InfantryNumber1);
                //InfantryNumber1 = float.Parse(str);
                monnytext.text = "【步兵】" + "\n征召/裁军：" + (int)InfantryNumber1 + "\n征召总价/裁军总价：" + (int)InfantryNumber1 * 3 + "/" + (int)InfantryNumber1 * 4;
            }
            else
            {

                monnytext.text = "请输入数字";
            }
        }
    }
    public void Archeradd()
    {

        float ArcherNumber;
        float monny;
        ArcherNumberstr = Archerin.textComponent.text;
        if (isnumeric(ArcherNumberstr))
        {
            ArcherNumber = int.Parse(ArcherNumberstr);
            monny= ArcherNumber * 3;
            // print(InfantryNumber1);
            
           
            // PlayerPrefs.SetFloat("monny", monny);
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.ArcherNumber += (int)ArcherNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "征召成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }
    }
    public void Archerreduce()
    {
        float ArcherNumber;
        float monny;
        ArcherNumberstr = Archerin.textComponent.text;
        if (isnumeric(ArcherNumberstr))
        {
            ArcherNumber= int.Parse(ArcherNumberstr);
            monny= ArcherNumber* 4;
            
           
            monny = PlayerPrefs.GetFloat("monny");
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.ArcherNumber -= (int)ArcherNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "裁军成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void Archertext(string str)
    {
        int ArcherNumber1;
        // print(str);
        ArcherNumberstr = Archerin.textComponent.text;
        //float monny1;
        if (ArcherNumberstr != null)
        {
            if (isnumeric(ArcherNumberstr))
            {
                int.TryParse(ArcherNumberstr, out ArcherNumber1);
                //   print(InfantryNumber1);
                //InfantryNumber1 = float.Parse(str);
                monnytext.text = "【弓兵】" + "\n征召/裁军：" + (int)ArcherNumber1 + "\n征召总价/裁军总价：" + (int)ArcherNumber1 * 3 + "/" + (int)ArcherNumber1 * 4;
            }
            else
            {

                monnytext.text = "请输入数字";
            }
        }
    }
    public void mauleradd()
    {

        float maulerNumber;
        float monny;
        maulerNumberstr = maulerin.textComponent.text;
        if (isnumeric(maulerNumberstr))
        {
            maulerNumber = int.Parse(maulerNumberstr);
            monny = maulerNumber * 3;
            
           
            // PlayerPrefs.SetFloat("monny", monny);
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.maulerNumber += (int)maulerNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "征召成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void maulerreduce()
    {
        float maulerNumber;
        float monny;
        maulerNumberstr = maulerin.textComponent.text;
        if (isnumeric(maulerNumberstr))
        {
            maulerNumber = int.Parse(maulerNumberstr);
            monny = maulerNumber * 4;
          
           
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.maulerNumber -= (int)maulerNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "裁军成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }
    }
    public void maulertext(string str)
    {
        int maulerNumber1;
        // print(str);
        maulerNumberstr = maulerin.textComponent.text;
        //float monny1;
        if (maulerNumberstr != null)
        {
            if (isnumeric(maulerNumberstr))
            {
                int.TryParse(maulerNumberstr, out maulerNumber1);
                //   print(InfantryNumber1);
                //InfantryNumber1 = float.Parse(str);
                monnytext.text = "【盾兵】" + "\n征召/裁军：" + (int)maulerNumber1 + "\n征召总价/裁军总价：" + (int)maulerNumber1 * 3 + "/" + (int)maulerNumber1 * 4;
            }
            else
            {

                monnytext.text = "请输入数字";
            }
        }
    }
    public void cavalryadd()
    {

        float cavalryNumber;
        float monny;
        cavalryNumberstr = cavalryin.textComponent.text;
        if (isnumeric(cavalryNumberstr))
        {
            cavalryNumber = int.Parse(cavalryNumberstr);
            monny = cavalryNumber * 3;
            //print(InfantryNumber1);
         
            // PlayerPrefs.SetFloat("monny", monny);
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.cavalryNumber += (int)cavalryNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "征召成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void cavalryreduce()
    {
        float cavalryNumber;
        float monny;
        cavalryNumberstr = cavalryin.textComponent.text;
        if (isnumeric(cavalryNumberstr))
        {
            cavalryNumber = int.Parse(cavalryNumberstr);
            monny = cavalryNumber * 4;
          
            if (GameManager.getInstance().playerData.money < monny)
            {
                monnytext.text = "钱不够";
            }
            else
            {
                GameManager.getInstance().playerData.cavalryNumber -= (int)cavalryNumber;
                GameManager.getInstance().playerData.money -= (int)monny;
                monnytext.text = "裁军成功";
                changeText();
            }

        }
        else
        {
            //Infantryin.textComponent.text="请输入数字";

        }

    }
    public void cavalrytext(string str)
    {
        int cavalryNumber1;
        // print(str);
        cavalryNumberstr = cavalryin.textComponent.text;
        //float monny1;
        if (cavalryNumberstr != null)
        {
            if (isnumeric(cavalryNumberstr))
            {
                int.TryParse(cavalryNumberstr, out cavalryNumber1);
                //   print(InfantryNumber1);
                //InfantryNumber1 = float.Parse(str);
                monnytext.text = "【骑兵】" + "\n征召/裁军：" + (int)cavalryNumber1 + "\n征召总价/裁军总价：" + (int)cavalryNumber1 * 3 + "/" + (int)cavalryNumber1 * 4;
            }
            else
            {

                monnytext.text = "请输入数字";
            }
        }
    }
    //升级
    public void aShenJI()
    {
        int LV = GameManager.getInstance().playerData.ArcherLV;
        int xd = GameManager.getInstance().playerData.lianBinXingde;
        if (getNeedSenJi(LV)<xd) {
            GameManager.getInstance().playerData.lianBinXingde -= getNeedSenJi(LV);
            GameManager.getInstance().playerData.ArcherLV += 1;
            monnytext.text = "升级成功";

        }
        else {
            monnytext.text = "练兵心得数量不够，需要"+ getNeedSenJi(LV)+"个";
        }

    }
    public void iShenJI()
    {
        int LV = GameManager.getInstance().playerData.InfantryLV;
        int xd = GameManager.getInstance().playerData.lianBinXingde;
        if (getNeedSenJi(LV) < xd)
        {
            GameManager.getInstance().playerData.lianBinXingde -= getNeedSenJi(LV);
            GameManager.getInstance().playerData.InfantryLV += 1;
            monnytext.text = "升级成功";

        }
        else
        {
            monnytext.text = "练兵心得数量不够，需要" + getNeedSenJi(LV) + "个";
        }
    }
    public void mShenJI()
    {
        int LV = GameManager.getInstance().playerData.maulerLV;
        int xd = GameManager.getInstance().playerData.lianBinXingde;
        if (getNeedSenJi(LV) < xd)
        {
            GameManager.getInstance().playerData.lianBinXingde -= getNeedSenJi(LV);
            GameManager.getInstance().playerData.maulerLV += 1;
            monnytext.text = "升级成功";

        }
        else
        {
            monnytext.text = "练兵心得数量不够，需要" + getNeedSenJi(LV) + "个";
        }

    }
    public void cShenJI()
    {
        int LV = GameManager.getInstance().playerData.cavalryLV;
        int xd = GameManager.getInstance().playerData.lianBinXingde;
        if (getNeedSenJi(LV) < xd)
        {
            GameManager.getInstance().playerData.lianBinXingde -= getNeedSenJi(LV);
            GameManager.getInstance().playerData.cavalryLV += 1;
            monnytext.text = "升级成功";

        }
        else
        {
            monnytext.text = "练兵心得数量不够，需要" + getNeedSenJi(LV) + "个";
        }

    }
    //进阶
    public void aJinJie()
    {
        biaoJi = "a";
        int LV = GameManager.getInstance().playerData.ArcherLV;
        string name= GameManager.getInstance().playerData.ArcherName;
        if (LV >= 10 && name != "lianNuBin")
        {
            biaoJiName = "lianNuBin";
            jinJiechen.SetActive(true);
            jinJieText.text = "是否进阶为连弩兵";
        }
        else
        {
            if (LV >= 5 && name != "nuBin")
            {
                biaoJiName = "nuBin";
                jinJiechen.SetActive(true);
                jinJieText.text = "是否进阶为弩兵";
                monnytext.text = "";
            }
            else
            {
                monnytext.text = "进阶等级不足";
            }
           // monnytext.text = "进阶等级不足";
        }

       
    }
    public void iJinJie()
    {
        biaoJi = "i";
        int LV = GameManager.getInstance().playerData.InfantryLV;
        string name = GameManager.getInstance().playerData.InfantryName;
        if (LV >= 10 && name != "cheBin")
        {
            biaoJiName = "cheBin";
            jinJiechen.SetActive(true);
            jinJieText.text = "是否进阶为车兵";
        }
        else
        {
            if (LV >= 5 && name != "zhongBuBin")
            {
                biaoJiName = "zhongBuBin";
                jinJiechen.SetActive(true);
                jinJieText.text = "是否进阶为重步兵";
                monnytext.text = "";
            }
            else
            {
                monnytext.text = "进阶等级不足";
            }
            //monnytext.text = "进阶等级不足";
        }
        

    }
    public void mJinJie()
    {
        biaoJi = "m";
        int LV = GameManager.getInstance().playerData.maulerLV;
        string name = GameManager.getInstance().playerData.maulerName;
        if (LV >= 10 && name != "maoDunBin")
        {
            biaoJiName = "maoDunBin";
            jinJiechen.SetActive(true);
            jinJieText.text = "是否进阶为矛盾兵";
        }
        else
        {
            if (LV >= 5 && name != "daoDunBin")
            {
                biaoJiName = "daoDunBin";
                jinJiechen.SetActive(true);
                jinJieText.text = "是否进阶为刀盾兵";
                monnytext.text = "";
            }
            else
            {
                monnytext.text = "进阶等级不足";
            }
        }

        


    }
    public void cJinJie()
    {
        biaoJi = "c";
        int LV = GameManager.getInstance().playerData.cavalryLV;
        string name = GameManager.getInstance().playerData.cavalryName;
        if (LV >= 10 && name != "gongQiBin")
        {
            biaoJiName = "gongQiBin";
            jinJiechen.SetActive(true);
            jinJieText.text = "是否进阶为弓骑兵";
        }
        else
        {
            if (LV >= 5 && name != "zhongQiBin")
            {
                biaoJiName = "zhongQiBin";
                jinJiechen.SetActive(true);
                jinJieText.text = "是否进阶为重骑兵";
                monnytext.text = "";
            }
            else
            {
                monnytext.text = "进阶等级不足";
            }
          //  monnytext.text = "进阶等级不足";
        }
       
      
    }
    public void returnTiaoBing() {

        tiaobinchen.SetActive(false);
    }
    //进阶选择1
    public void jinJieXuanZhe1()
    {
        switch (biaoJi) {
            case "a":
                GameManager.getInstance().playerData.ArcherName =biaoJiName;
                jinJieText.text = "进阶成功";
                break;
            case "m":
                GameManager.getInstance().playerData.maulerName = biaoJiName;
                jinJieText.text = "进阶成功";
                break;
            case "i":
                GameManager.getInstance().playerData.InfantryName = biaoJiName;
                jinJieText.text = "进阶成功";
                break;
            case "c":
                GameManager.getInstance().playerData.cavalryName = biaoJiName;
                jinJieText.text = "进阶成功";
                break;

        }
        changeText();

    }
    //进阶选择2
    public void jinJieXuanZhe2()
    {

    }
    //进阶返回
    public void jinJieFanHui()
    {
        jinJiechen.SetActive(false);
    }
    public int getNeedSenJi(int lv) {
        if (lv >= 0)
        {
            if (lv <= 3)
            {
                return 3;
            }
            if (lv > 3 && lv <= 8)
            {
                return 5;
            }
            if (lv > 8 && lv <= 13)
            {
                return 10;
            }
            if (lv == 14)
            {
                return 20;
            }
            if (lv == 15)
            {
                return 25;
            }
            if (lv == 16)
            {
                return 30;
            }
            if (lv == 17)
            {
                return 35;

            }
        }
        else {
            return 1;

          
        }
        return 1;
    }
    public bool isnumeric(string str)
    {
        char[] ch = new char[str.Length];
        ch = str.ToCharArray();
        for (int i = 0; i < str.Length; i++)
        {
            if (ch[i] < 48 || ch[i] > 57)
                return false;
        }
        return true;
    }
    void Awake()
    {
        tb = this;


    }
    private static tiaobin tb;
    public static tiaobin getInstance()
    {

        return tb;
    }
}
