using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : ALLsoldiers
{

    // Use this for initialization
   // public Vector2 speed;
    public float life;
    public float damage;
    public float frequency;
    public int jianShu;//箭的数量
    public bool isshoot=false;
    public GameObject arrow;
    public RectTransform Parent;
    /// <summary>
    /// Moving direction
    /// </summary>
  

    private Vector2 movement;
    
     void Start()
    {
        //  Parent = GameObject.Find("BattleCanvas").GetComponent<RectTransform>();

        Parent = GameObject.Find("BattleScene").GetComponent<RectTransform>();
        theStart();
        //判断名字
        if (MyShoot.getInstance().ArcherName == "lianNuBin") {
            jianShu = 4;
        } else {
            jianShu = 2;
        }

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
        if (isshoot == false)
        {
            this.GetComponent<Rigidbody2D>().position += movement;
            //判断攻距
            float a = wallY - this.transform.position.y;
            print("a" + a);
            print("dis"  +disOld * (1-Distance));
            if (disOld * (1 - Distance) >= a)
            {

                isshoot = true;
                direction.y = 0;
                StartCoroutine(ArcherAttack());
            }
        }
        else {
           
           
            
        }
    }
    IEnumerator ArcherAttack()
    {

       
        
        GameObject go = Instantiate(arrow, this.transform.position, this.transform.rotation) ;
        go.transform.SetParent(Parent);//设置父节点
        yield return new WaitForSeconds(Random.Range(1.1f, 1.2f));
       
        frequency += 1;
        if (frequency >= jianShu)
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
       
        if (this.tag == "Archer")
        {
            if (otherCollider.tag == "myArcherwall")
            {
              //  isshoot = true;
               // isshoot = true;
               // direction.y = 0;
               // StartCoroutine(ArcherAttack());
            }
            if (otherCollider.tag == "Enemywall")
            {
                // GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().AIsoldiersdamage(damage);
                this.gameObject.SetActive(false);
            }
            if (otherCollider.tag == "EnemyInfantry")
            {
                lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "EnemyArcher")
            {
                lifeReduce(otherCollider);
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
