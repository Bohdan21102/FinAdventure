using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ResetAll()
    {
        Save.Reset();
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            ResetAll();
        }
    }
}
