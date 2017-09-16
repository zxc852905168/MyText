using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ALLsoldiers : MonoBehaviour {
    public float Need;

    public float Food;
    public float Life;
    public float nowLife; //现在的生命值
    public float Distance;
    public float Speed;
    public float damageMAX;
    public float damageMIN;
    public float LV;
    public float disOld;//记录开始距离
    public float wallY;
    //Image myImage;
    public Image image2;
    Image image;
    public string spiritLoad;
    public Vector2 direction;
    //   public Vector2 direction;

    //  private Vector2 movement;
    // Use this for initialization
    void Start() {
        //battlecontrol.gameover1 += gameover1;
        //  readArmsXMLData();//myshoot的单例
        //  readMyArmsData();//读取数据
    }
    private void OnEnable()
    {
        BattleManager.battleOver += gameover;
    }
    public void theStart() {
        //  image = this.GetComponent<SpriteRenderer>();
        readMyArmsData();
        nowLife = Life;
        //MyShoot.getInstance().
        BattleManager.getInstance().myFoodReduce(Food);
        BattleManager.getInstance().mySoilderReduce(Need, this.tag);//减少士兵
        this.GetComponent<Image>().sprite = Resources.Load(spiritLoad, typeof(Sprite)) as Sprite;

        wallY = GameObject.Find("Enemywall").transform.position.y;
        disOld = wallY - this.transform.position.y;

    }
    //判断攻距
    public void gongJu() {
        float a = wallY - this.transform.position.y;
        print("a" + a);
        print("dis" + disOld * (1 - Distance));
        if (disOld * (1 - Distance) >= a)
        {

           
            direction.y = 10;
           
        }

    }
    //读取arms.xml文件的内容
    public string readArmsXMLData(string itemName , string value)
    {
       // string fileName = Application.dataPath + "/Data/Arms.xml";
        string fileName = Resources.Load("Arms").ToString();
        return Func.getInstance().readXMLArmsData( fileName, itemName,  value);
    }
    public void readMyArmsData() {
      string theName="";
        theName= myNameAndLV();//如果是我的兵种


        Need = float.Parse(readArmsXMLData(theName, "Need"))+LV;
 
        Food = float.Parse(readArmsXMLData(theName, "Food")) + LV;
        Life = float.Parse(readArmsXMLData(theName, "Life")) ;
        Distance = float.Parse(readArmsXMLData(theName, "Distance")) ;
        Speed = float.Parse(readArmsXMLData(theName, "Speed")) ;
        damageMAX = float.Parse(readArmsXMLData(theName, "MAX")) + LV;
        damageMIN = float.Parse(readArmsXMLData(theName, "MIN")) + LV;
        spiritLoad = readArmsXMLData(theName, "spirit");


    }
    public string myNameAndLV() {
        string name = "";
        MyShoot ms = MyShoot.getInstance();
        if (this.tag == "Infantry")
        {
            name = ms.InfantryName;
            LV = GameManager.getInstance().playerData.InfantryLV;
        }
        if (this.tag == "Archer")
        {
            name = ms.ArcherName;
            // print("SB");
            LV = GameManager.getInstance().playerData.ArcherLV;
        }
        if (this.tag == "mauler")
        {
            name = ms.maulerName;
            LV = GameManager.getInstance().playerData.maulerLV;
        }
        if (this.tag == "cavalry")
        {

            name = ms.cavalryName;
            LV = GameManager.getInstance().playerData.cavalryLV;
        }
        return name;
    }
    //生命减少
    public void lifeReduce(Collider2D otherCollider)
    {
      nowLife-=  otherCollider.GetComponent<EnemyALLsoldiers>().Life;
        this.GetComponent<Image>().color = new Color32(204, 201, 197, 230);
       
        if (nowLife<=0) {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

        }
    }
    //伤害
    public void theDamage() {

        BattleManager.getInstance().enemyDamage(Random.Range(damageMIN, damageMAX));
    }
  /*  public void des(){
       // this.GetComponent<Renderer>().enabled = false;
       this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
       this.gameObject. GetComponent<CircleCollider2D>().enabled = false;
    }*/

    public void gameover() {
        BattleManager.battleOver -= gameover;
        print("dead");
       Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
