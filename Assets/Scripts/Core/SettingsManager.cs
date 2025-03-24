using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Reset()
    {
        Save.Reset();
        SceneManager.LoadScene(0);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
