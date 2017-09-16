using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mauler : ALLsoldiers
{

    // Use this for initialization
    //public Vector2 speed;
    public float life=2;
    public float damage;
    bool yiFu=false;//是不是一夫当关
    /// <summary>
    /// Moving direction
    /// </summary>
   // public Vector2 direction;

    private Vector2 movement;
    private void Start()
    {
        theStart();
        if (yiFu==true) {
            nowLife = 6;
            Life = 6;
        }
    }
    void Update()
    {
        // 2 - Movement
       
        movement = new Vector2(
       0,
        Speed * direction.y);
    }
    public void setOneMan()
    {
        yiFu = true;
        nowLife = 6;
       this.GetComponent<Image>().color = Color.red;
    }
    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
        gongJu();
    }
    //public 
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       

        if (this.tag == "mauler")
        {
            if (otherCollider.tag == "Enemywall")
            {
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                theDamage();
               this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                //print("ss");
                lifeReduce(otherCollider); ;
            }
            if (otherCollider.tag == "EnemyArcher")
            {
                //print("ss");
            }
            if (otherCollider.tag == "Enemymauler")
            {
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "Enemycavalry")
            {
                lifeReduce(otherCollider);
            }
        }
      
    }
}
