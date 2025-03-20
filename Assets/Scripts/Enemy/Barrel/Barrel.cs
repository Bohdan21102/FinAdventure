using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public bool CanHurt;
    public int hpless = 0;
    public int health;
    public int MaxHP;
    public HP_manager hptxt;

    public GameObject coin;
    public int coinsCount = 5;

    void Start()
    {
        hpless = FindObjectOfType<PlayerControler>().hurt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackColider"))
        {
            CanHurt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackColider"))
        {
            CanHurt = false;
        }
    }

    private void OnMouseDown()
    {
        if (!CanHurt) return;

        ApplyDamage();
    }

    private void ApplyDamage()
    {
        health -= hpless;

        if (health <= 0)
        {
            SpawnCoins();
            Destroy(gameObject);
        }
        hptxt.LastHurtEnemy = this.gameObject;
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < coinsCount + 1; i++)
        {
            Vector3 positionOffset = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), transform.position.z);
            Instantiate(coin, transform.position + positionOffset, Quaternion.identity);
        }
    }
}