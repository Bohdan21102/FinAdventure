using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool visible;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] bool canAttack = false;
    [SerializeField] bool canHurt = false;

    [SerializeField] float speed = 5f;
    [SerializeField] public int HP;
    [SerializeField] public int MaxHP;
    [SerializeField] HP_manager hptxt;
    [SerializeField] public int hurt = 10;
    [SerializeField] GameObject coin;
    [SerializeField] int coinsCount = 5;

    void Start()
    {
        target = FindObjectOfType<PlayerControler>().gameObject;
        hptxt = FindAnyObjectByType<HP_manager>().GetComponent<HP_manager>();
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void FixedUpdate()
    {
        if (canAttack)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackColider"))
        {
            canHurt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackColider"))
        {
            canHurt = false;
        }
    }

    private void OnMouseDown()
    {
        if (canHurt)
        {
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        HP -= target.GetComponent<PlayerControler>().hurt;
        GameObject.FindObjectOfType<SoundManager>().Hurt();

        if (HP <= 0)
        {
            SpawnCoins();
            Destroy(gameObject);
        }
        hptxt.LastHurtEnemy = this.gameObject;
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < coinsCount + 1 + Save.coinboost; i++)
        {
            Vector3 positionOffset = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), transform.position.z);
            Instantiate(coin, transform.position + positionOffset, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (transform.GetChild(0).gameObject.GetComponent<EnemyVision>().isPlayerSeen)
        {
            if (visible) canAttack = true;
        }
    }
}