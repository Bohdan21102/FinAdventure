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
        GameObject.FindObjectOfType<SoundManager>().Click();
        SceneManager.LoadScene(1);
        Save.playedBefore=true;
    }

    public void Settingd()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        SceneManager.LoadScene(8);
        
    }
    public void Close()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        Application.Quit();
    }
    private void Update()
    {
        anim(GameObject.Find("Title").GetComponent<RectTransform>());
        anim(GameObject.Find("Play").GetComponent<RectTransform>());
    }
    private void anim(RectTransform animbutton)
    {
        float scale = 1f + Mathf.Sin(Time.time * 2) * 0.1f;
        animbutton.localScale = new Vector3(scale, scale, 1f);
    }
}
