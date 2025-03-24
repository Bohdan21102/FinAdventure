using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        if(!Save.playedBefore)
        {
            Save.Reset();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Save.playedBefore=true;
    }

    public void Settingd()
    {
        SceneManager.LoadScene(8);
        
    }
    public void Close()
    {
        Application.Quit();
    }
}
