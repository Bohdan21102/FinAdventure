using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int scene;
    public GameObject exit;
    private void Start()
    {
        exit.GetComponent<Animator>().Play("Open");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            exit.GetComponent<Animator>().Play("Exit");
            Save.coins = collision.gameObject.GetComponent<PlayerControler>().coins;
            Save.SaveCoin();
            new WaitForSeconds(0.5f);
            SceneManager.LoadScene(scene);
        }
    }
}
