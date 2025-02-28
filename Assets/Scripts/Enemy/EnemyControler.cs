using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private GameObject target;
    private bool visible;
    private Rigidbody2D rb2d;
    private bool canAttack = false;
    private bool canHurt = false;
    //знизу public, зверху private
    public float speed = 5f;
    public int HP;
    public int MaxHP;
    public HP_manager hptxt;
    public int hurt = 10;
    public GameObject coin;
    public int coinsCount = 5;

    void Start()
    {
        target = FindObjectOfType<PlayerControler>().gameObject;
        hptxt=FindAnyObjectByType<HP_manager>().GetComponent<HP_manager>();
    }

    // Update is called once per frame
    private void OnBecameVisible()
    {
        visible = true;
    }
    private void FixedUpdate()
    {
        if (canAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="AttackColider")
        {
            canHurt=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackColider")
        {
            canHurt = false;
        }
    }
    private void OnMouseDown()
    {
        if(canHurt)
        {
            HP -= target.GetComponent<PlayerControler>().hurt;
            
            if (HP <= 0)
            {
                Save.Getcoinboost(); 
                for(int i =0; i<coinsCount+1 + Save.coinboost; i++)
                {
                    Instantiate(coin, transform.position + new Vector3(Random.Range(-2, 2),Random.Range(-2,2),transform.position.z), Quaternion.identity);
                }
                Destroy(gameObject);
            }
            hptxt.LastHurtEnemy = this.gameObject;
        }
        
    }
    private void Update()
    {
        if (transform.GetChild(0).gameObject.GetComponent<EnemyVision>().isPlayerSeen)
        {
            if(visible) canAttack = true;
        }
    }
}
