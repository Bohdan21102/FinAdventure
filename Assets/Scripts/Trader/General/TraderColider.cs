using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderColider : MonoBehaviour
{
    [SerializeField] GameObject trader;

    private TraderSword swordTrader;
    private HealthTrader healthTrader;
    private CoinTrader coinTrader;
    private BankMan bankman;
    private DepositMan depman;

    void Start()
    {
        trader = transform.parent.gameObject;
        //finding trader script
        swordTrader = trader.GetComponent<TraderSword>();
        healthTrader = trader.GetComponent<HealthTrader>();
        coinTrader = trader.GetComponent<CoinTrader>();
        bankman = trader.GetComponent<BankMan>();
        depman = trader.GetComponent<DepositMan>();

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetTraderStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetTraderStatus(false);
        }
    }

    private void SetTraderStatus(bool status)
    {
        //change isPlayerThere
        if (coinTrader != null)
        {
            coinTrader.isPlayerThere = status;
        }

        if (bankman != null)
        {
            bankman.isPlayerThere = status;
        }

        if (swordTrader != null)
        {
            swordTrader.isPlayerThere = status;
        }

        if (healthTrader != null)
        {
            healthTrader.isPlayerThere = status;
        }
        if (depman != null)
        {
            depman.isPlayerThere = status;
        }
    }
}
