using System.Collections;
using UnityEngine;

public class DepositTimer : MonoBehaviour
{
    public DepositMan depMan;
    private PlayerControler playerControler;

    public int cuttime;
    private const int maxTime = 300;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize(DepositMan depManRef)
    {
        depMan = depManRef;
        playerControler = FindObjectOfType<PlayerControler>();
    }

    void Start()
    {
        cuttime = maxTime;
        UpdateTimerText();
        StartCoroutine(Timer());
    }
    //timer
    private IEnumerator Timer()
    {
        while (cuttime > 0)
        {
            yield return new WaitForSeconds(1);
            cuttime--;
            UpdateTimerText();
        }

        depMan.TimerEnded();
        playerControler.coins += 110;
        Destroy(gameObject);
    }

    private void Update()
    {
        UpdateTimerText();
    }
    //update text
    private void UpdateTimerText()
    {
        if (depMan != null)
        {
            depMan.timertxt.text = cuttime.ToString();
        }
    }
}