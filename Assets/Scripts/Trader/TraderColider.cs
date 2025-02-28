using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderColider : MonoBehaviour
{
    public GameObject trader;

    void Start()
    {
        trader = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var swordTrader = trader.GetComponent<TraderSword>();
            var healthTrader = trader.GetComponent<HealthTrader>();

            if (swordTrader != null) swordTrader.isplayerthere = true;
            if (healthTrader != null) healthTrader.isplayerthere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var swordTrader = trader.GetComponent<TraderSword>();
            var healthTrader = trader.GetComponent<HealthTrader>();

            if (swordTrader != null) swordTrader.isplayerthere = false;
            if (healthTrader != null) healthTrader.isplayerthere = false;
        }
    }
}
