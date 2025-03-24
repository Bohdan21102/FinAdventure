using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToDungeon : MonoBehaviour
{
    [SerializeField] int minscene;
    [SerializeField] int maxscene;
    [SerializeField] GameObject exit;

    private void Start()
    {
        exit = GameObject.Find("Exit");
        exit.GetComponent<Animator>().Play("Open");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exit.GetComponent<Animator>().Play("Exit");
            Save.coins = collision.gameObject.GetComponent<PlayerControler>().coins;
            Save.SaveCoin();
            StartCoroutine(LoadSceneAfterDelay(0.4f));
        }
    }
    //open secen after short delay
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Random.Range(minscene, maxscene));
    }
}
