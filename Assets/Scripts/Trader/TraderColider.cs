using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderColider : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject trader;

    void Start()
    {

        trader=GetComponentInParent<Transform>().gameObject;
        Debug.Log(trader);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if (collision.gameObject.tag == "Player")
        {
            if (trader.GetComponent<TraderSword>() != null)
            {
                trader.GetComponent<TraderSword>().isplayerthere = true;
            }
            else if (trader.GetComponent<HealthTrader>() != null)
            {
                trader.GetComponent<HealthTrader>().isplayerthere = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (trader.GetComponent<TraderSword>() != null)
            {
                trader.GetComponent<TraderSword>().isplayerthere = false;
            }
            else if(trader.GetComponent<HealthTrader>()!=null)
            {
                trader.GetComponent<HealthTrader>().isplayerthere = false;
            }
        }
    }
}
