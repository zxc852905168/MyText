using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfantry : EnemyALLsoldiers
{

    // Use this for initialization
    public Vector2 speed ;
    public float life;
    public float damage;
    /// <summary>
    /// Moving direction
    /// </summary>
 //   public Vector2 direction ;

    private Vector2 movement;
    private void Start()
    {
        // readMyArmsData();
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
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
            if (this.tag == "EnemyInfantry")
        {
            if (otherCollider.tag == "mywall")
            {
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
                theDamage();
              this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
            if (otherCollider.tag == "Infantry")
            {
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "Archer")
            {
                //print("ss");
            }
            if (otherCollider.tag == "mauler")
            {
                lifeReduce(otherCollider);
                // print("ss");
            }
            if (otherCollider.tag == "cavalry")
            {
                lifeReduce(otherCollider);
                // print("ss");
            }
        }
        
      
    }
}
