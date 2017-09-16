using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMauler : EnemyALLsoldiers
{

    // Use this for initialization
    public Vector2 speed;
    public float life=2;
    public float damage;
    bool yiFu = false;//是不是一夫当关
    /// <summary>
    /// Moving direction
    /// </summary>
 //   public Vector2 direction;

    private Vector2 movement;
    private void Start()
    {
        theStart();
        if (yiFu == true)
        {
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

        nowLife = 6;
        yiFu = true;
        this.GetComponent<Image>().color = Color.red;
    }
    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
    }
    //public 
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (this.tag == "Enemymauler")
        {
            if (otherCollider.tag == "mywall")
            {
                //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                theDamage();
                this.gameObject.SetActive(false);
               // Destroy(this.gameObject);
            }
            if (otherCollider.tag == "Infantry")
            {
                //print("ss");
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "Archer")
            {
                //print("ss");
            }
            if (otherCollider.tag == "mauler")
            {
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "cavalry")
            {
                lifeReduce(otherCollider);
            }
        }

        
      
    }
}
