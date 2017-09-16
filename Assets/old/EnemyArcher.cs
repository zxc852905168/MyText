using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyALLsoldiers
{

    // Use this for initialization
    public Vector2 speed;
    public float life;
    public float damage;
    public float frequency;
    public bool isshoot;
    public GameObject arrow;
    public RectTransform Parent;
    /// <summary>
    /// Moving direction
    /// </summary>
//  public Vector2 direction;

    private Vector2 movement;
    private void Start()
    {
        //  Parent = GameObject.Find("BattleCanvas").GetComponent<RectTransform>();

        Parent = GameObject.Find("BattleScene").GetComponent<RectTransform>();

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
        if (isshoot == false)
        {
            this.GetComponent<Rigidbody2D>().position += movement;
            float a = this.transform.position.y-wallY  ;
            print("a" + a);
            print("dis" + disOld * (1 - Distance));
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
        print("aa");
        
            if (otherCollider.tag == "EnemyArcherwall")
            {
                //isshoot = true;
               // direction.y = 0;
               // StartCoroutine(ArcherAttack());
            }
                if (otherCollider.tag == "mywall")
            {
             //   GameObject.Find("BattleCanvas").GetComponent<battlecontrol>().soldiersdamage(damage);
               // Destroy(this.gameObject);
            }
            print("aas");
            if (otherCollider.tag == "Infantry")
            {
            lifeReduce(otherCollider);
            }
            if (otherCollider.tag == "Archer")
            {
            //print("ss");
            lifeReduce(otherCollider);
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
