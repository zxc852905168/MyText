using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    private void OnEnable()
    {
        BattleManager.battleOver += gameover;
    }

    void Update()
    {
        // 2 - Movement
        // movement = new Vector2(
        //  0
        // speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (this.tag == "enemyarrow")
        {
            new Vector3(0, 0, 180);
            transform.rotation = Quaternion.Euler(0, 0, -180);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -2);
        }
        if (this.tag == "arrow")
        {
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 2);
        }
        if (this.tag == "strongeArrow")
        {
           // new Vector3(0, 0, 180);
            //transform.rotation = Quaternion.Euler(0, 0, -180);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 5);
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Enemywall")
        {
            //theDamage();
            if (this.tag == "strongeArrow")
            {
                // new Vector3(0, 0, 180);
                //transform.rotation = Quaternion.Euler(0, 0, -180);
                //this.GetComponent<Rigidbody2D>().position += new Vector2(0, -2);
                BattleManager.getInstance().enemyDamage(Random.Range(40, 50));
            }
            else
            {
                BattleManager.getInstance().enemyDamage(Random.Range(5, 15));
            }
            // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(20);
            this.gameObject.SetActive(false);
           // Destroy(this.gameObject);
        }
        if (otherCollider.tag == "mywall")
        {
           // theDamage();
            BattleManager.getInstance().myDamage(Random.Range(5, 15));
            //  GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(20);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }


    }
    public void gameover()
    {
        //print("dead");
        BattleManager.battleOver -= gameover;
        Destroy(this.gameObject);

        //this.gameObject.SetActive(false);
    }

}