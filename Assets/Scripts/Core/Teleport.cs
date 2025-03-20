using System.Collections;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            exit.GetComponent<Animator>().Play("Exit");
            Save.coins = collision.gameObject.GetComponent<PlayerControler>().coins;
            Save.SaveCoin();
            StartCoroutine(LoadSceneAfterDelay(0.4f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}