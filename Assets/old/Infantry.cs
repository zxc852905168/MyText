using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : ALLsoldiers
{

    // Use this for initialization
  //  public Vector2 speed ;
    public float life;
    public float damage;
    /// <summary>
    /// Moving direction
    /// </summary>
  //  public Vector2 direction ;

    private Vector2 movement;
    private void Start()
    {
        theStart();
    }
    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          0,
           Speed * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
        gongJu();
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
           
        if (this.tag == "Infantry")
        {
            if (otherCollider.tag == "Enemywall")
            {
                //   GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                theDamage();
                this.gameObject.SetActive(false);
               // Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                //print("ss");
                lifeReduce(otherCollider);
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
