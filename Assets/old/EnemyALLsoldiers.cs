using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyALLsoldiers : MonoBehaviour {
  public   float Need;
    public float Food;
    public float Life;
    public float Distance;
    public float Speed;
    public float damageMAX;
    public float damageMIN;
    public float LV;
    public float nowLife;//现在的生命值
    public string spiritLoad;
    public float disOld;//记录开始距离
    public float wallY;
    public Vector2 direction;
    //   public Vector2 direction;

    //  private Vector2 movement;
    // Use this for initialization
    void Start () {
       // battlecontrol.gameover1 += gameover1;
        //  readArmsXMLData();//myshoot的单例
       // readMyArmsData();//读取数据
    }
    private void OnEnable()
    {
        BattleManager.battleOver += gameover;
    }
    //共同的start
    public void theStart()
    {
        readMyArmsData();
        nowLife = Life;
        BattleManager.getInstance().enemyFoodReduce(Food);
        BattleManager.getInstance().enemySoilderReduce(Need,this.tag);
        this.GetComponent<Image>().sprite = Resources.Load(spiritLoad, typeof(Sprite)) as Sprite;
        wallY = GameObject.Find("mywall").transform.position.y;
        disOld = this.transform.position.y - wallY;
    }
    //读取arms.xml文件的内容
    public string readArmsXMLData(string itemName , string value)
    {
        //string fileName = Application.dataPath + "/Data/Arms.xml";
        string fileName = Resources.Load("Arms").ToString();
        return Func.getInstance().readXMLArmsData( fileName, itemName,  value);
    }
    public void readMyArmsData() {
      //string name="";
       
     //  name);//如果是别人的兵种

        string theName = "";
        theName = enemyName();//
      

        Need = float.Parse(readArmsXMLData(theName, "Need"));

        Food = float.Parse(readArmsXMLData(theName, "Food"));
        Life = float.Parse(readArmsXMLData(theName, "Life"));
        Distance = float.Parse(readArmsXMLData(theName, "Distance"));
        Speed = float.Parse(readArmsXMLData(theName, "Speed"));
        damageMAX = float.Parse(readArmsXMLData(theName, "MAX"));
        damageMIN = float.Parse(readArmsXMLData(theName, "MIN"));
        spiritLoad = readArmsXMLData(theName, "spirit");
    }
   //兵种名字
    public string enemyName() {
        string name = "";
        EnemyShoot es = EnemyShoot.getInstance();
        if (this.tag == "EnemyInfantry")
        {

            name = es.InfantryName;
        }
        if (this.tag == "EnemyArcher")
        {
            name = es.ArcherName;

        }
        if (this.tag == "Enemycavalry")
        {
            name = es.cavalryName;
        }
        if (this.tag == "Enemymauler")
        {
            name = es.maulerName;

        }
        return name;
    }
    //生命减少
    public void lifeReduce(Collider2D otherCollider)
    {
        nowLife -= otherCollider.GetComponent<ALLsoldiers>().Life;
        this.GetComponent<Image>().color = new Color32(204, 201, 197, 230);
        if (nowLife <= 0)
        {
           // Destroy(this.gameObject);

            this.gameObject.SetActive(false);
        }
    }

    public void theDamage()
    {

        BattleManager.getInstance().myDamage(Random.Range(damageMIN, damageMAX));
    }
    /*
    public void des()
    {
        //this.GetComponent<Renderer>().enabled = false;
      this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
    */

    public void gameover() {
        BattleManager.battleOver -= gameover;
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }
}
