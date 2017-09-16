using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCavalry : EnemyALLsoldiers
{

    // Use this for initialization
    public Vector2 speed;
    public float life;
    public float damage;
    /// <summary>
    /// Moving direction
    /// </summary>
  //  public Vector2 direction;

    private Vector2 movement;
    private void Start()
    {
        theStart();
    }
    void Update()
    {
        // 2 - Movement
        int i;
        movement = new Vector2(
         0,
          Speed * direction.y);
    }
    public void setOneMan()
    {

        nowLife = 6;
        this.GetComponent<Image>().color = Color.red;
    }
    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (this.tag == "Enemycavalry")
        {
            if (otherCollider.tag == "mywall")
            {
                //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                // Destroy(this.gameObject);
                theDamage();
                this.gameObject.SetActive(false);
            }
            if (otherCollider.tag == "Infantry")
            {
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "Archer")
            {
               // this.Life -= otherCollider.GetComponent<ALLsoldiers>().Life;
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
