using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public void ResetAll()
    {
        Save.Reset();
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            ResetAll();
        }
    }
}
