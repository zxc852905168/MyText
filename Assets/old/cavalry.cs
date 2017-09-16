using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavalry : ALLsoldiers
{

    // Use this for initialization
    //public Vector2 speed;
    public float life;
    float aa;
    public float damage;
    public float frequency;
    public GameObject arrow;
    public bool isshoot = false;
    public RectTransform Parent;
    /// <summary>
    /// Moving direction
    /// </summary>
   // public Vector2 direction;

    private Vector2 movement;
    private void Start()
    {
        Parent = GameObject.Find("BattleScene").GetComponent<RectTransform>();
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
    
    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        this.GetComponent<Rigidbody2D>().position += movement;
        if (MyShoot.getInstance() .cavalryName== "gongQiBin") {
            if (isshoot == false)
            {
                this.GetComponent<Rigidbody2D>().position += movement;
                //判断攻距
                float a = wallY - this.transform.position.y;
                print("a" + a);
                print("dis" + disOld * (1 - Distance));
                if (disOld * (1 - Distance) >= a)
                {

                    isshoot = true;
                    direction.y = 0;
                    StartCoroutine(ArcherAttack());
                }
            }
        } else{

            gongJu();

        }
    }
    IEnumerator ArcherAttack()
    {



        GameObject go = Instantiate(arrow, this.transform.position, this.transform.rotation);
        go.transform.SetParent(Parent);//设置父节点
        yield return new WaitForSeconds(Random.Range(1.1f, 1.2f));

        frequency += 1;
        if (frequency >= 2)
        {
            // Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            // this.GetComponent<CanvasGroup>().alpha = 0;
            StopAllCoroutines();
            //StopCoroutine(ArcherAttack());
        }
        else
        {
            StartCoroutine(ArcherAttack());
        }

    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
        if (this.tag == "cavalry")
        {
            if (otherCollider.tag == "Enemywall")
            {
                //GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                theDamage();
                this.gameObject.SetActive(false);
               // Destroy(this.gameObject);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                lifeReduce(otherCollider);

            }
            if (otherCollider.tag == "EnemyArcher")
            {
                //this.Life -= otherCollider.GetComponent<ALLsoldiers>().Life;
                //print("ss");
               
            }
            if (otherCollider.tag == "Enemymauler")
            {
                lifeReduce(otherCollider);
                // print("ss");

            }
            if (otherCollider.tag == "Enemycavalry")
            {
                lifeReduce(otherCollider);

            }
        }
        if (this.Life <= 0)
        {
           // Destroy(this.gameObject);
          //des();

        }
    }
}
