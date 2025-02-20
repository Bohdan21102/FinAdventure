using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderColider : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform trader;

    void Start()
    {

        trader=GetComponentInParent<Transform>();
        Debug.Log(trader);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if(collision.gameObject.tag=="Player")
        {
            //Debug.Log("Player");
            if (trader.GetComponent<TraderSword>() != null)
            {
                Debug.Log("Trade");
                trader.GetComponent<TraderSword>().isplayerthere=true;
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
        }
    }
}
