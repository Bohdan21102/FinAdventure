using System.Collections;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool canCollect = false;
    public int value = 10;
    private Animator animator;

    void Start()
    {
        LoadCoinValue();
        animator = GetComponent<Animator>();
        StartCoroutine(EnableCollection());
    }

    private void LoadCoinValue()
    {
        Save.GetPrice();
        value = Save.price;
    }

    private IEnumerator EnableCollection()
    {
        yield return new WaitForSeconds(1);
        canCollect = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canCollect)
        {
            CollectCoin(collision);
        }
    }

    private void CollectCoin(Collider2D collision)
    {
        GameObject.FindObjectOfType<SoundManager>().Coin();
        collision.gameObject.GetComponent<PlayerControler>().coins += value;
        animator.Play("Collect");
        Destroy(gameObject, 0.3f);
    }
}