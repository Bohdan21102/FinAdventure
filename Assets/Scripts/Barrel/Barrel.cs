using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Barrel : MonoBehaviour
{

    public bool ÑanHurt;
    public int hpless=0;
    public int health;
    public HP_manager hptxt;

    public GameObject coin;
    public int coinsCount = 5;

    void Start()
    {
        hpless = FindObjectOfType<PlayerControler>().hurt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackColider")
        {
            ÑanHurt = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackColider")
        {
            ÑanHurt = false;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(0);
        if (ÑanHurt == true)
        {
            Debug.Log(1);
            health -= hpless;

            if (health <= 0)
            {

                for (int i = 0; i < coinsCount + 1; i++)
                {
                    Instantiate(coin, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), transform.position.z), Quaternion.identity);
                }
                Destroy(gameObject);
            }
            hptxt.LastHurtEnemy = this.gameObject;
        }
    }

}