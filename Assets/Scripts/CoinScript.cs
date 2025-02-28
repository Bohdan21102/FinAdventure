using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool cancollect = false;
    public int value = 10;
    private Animator animator;
    void Start()
    {
        Save.GetPrice();
        value=Save.price;
        animator = GetComponent<Animator>();
        new WaitForSeconds(1);
        cancollect = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player"&&cancollect)
        {
            collision.gameObject.GetComponent<PlayerControler>().coins += value;
            animator.Play("Collect");
            Destroy(gameObject,0.3f);
        }
    }
}
