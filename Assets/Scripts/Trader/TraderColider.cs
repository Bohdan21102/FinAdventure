using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderColider : MonoBehaviour
{
    public GameObject trader;

    private TraderSword swordTrader;
    private HealthTrader healthTrader;
    private CoinTrader coinTrader;
    private BankMan bankman;

    void Start()
    {
        trader = transform.parent.gameObject;

        // Cache references to all traders at the start
        swordTrader = trader.GetComponent<TraderSword>();
        healthTrader = trader.GetComponent<HealthTrader>();
        coinTrader = trader.GetComponent<CoinTrader>();
        bankman = trader.GetComponent<BankMan>();

        Debug.Log("swordTrader: " + swordTrader);
        Debug.Log("healthTrader: " + healthTrader);
        Debug.Log("coinTrader: " + coinTrader);
        Debug.Log("bankman: " + bankman);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Set isplayerthere to true for all relevant traders
            SetTraderStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Set isplayerthere to false for all relevant traders
            SetTraderStatus(false);
        }
    }

    private void SetTraderStatus(bool status)
    {
        // Ensure the components exist before setting their status
        if (coinTrader != null)
        {
            coinTrader.isplayerthere = status;
        }

        if (bankman != null)
        {
            bankman.isPlayerThere = status;
        }

        if (swordTrader != null)
        {
            swordTrader.isplayerthere = status;
        }

        if (healthTrader != null)
        {
            healthTrader.isplayerthere = status;
        }
    }
}
