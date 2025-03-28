using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject panel_;
    private void Start()
    {
        Time.timeScale = 1;
        panel_ = GameObject.Find("PausePanel").gameObject;
        panel_.SetActive(false);
    }
    public void ResetAll()
    {
        Save.Reset();
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
           // ResetAll();
        }
    }

    public void PauseMenu()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        panel_.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenScene(int sceneId)
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        SceneManager.LoadScene(sceneId);
    }
    public void ClosePauseMenu()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        panel_.SetActive(false);
        Time.timeScale = 1;
    }
}
