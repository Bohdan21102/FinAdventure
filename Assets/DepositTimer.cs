using System.Collections;
using UnityEngine;

public class DepositTimer : MonoBehaviour
{
    public DepositMan bankMan;
    private PlayerControler playerControler;

    public int cuttime;
    private int maxTime = 300;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize(DepositMan depManRef)
    {
        bankMan = depManRef;
        playerControler = FindObjectOfType<PlayerControler>();
    }

    void Start()
    {
        cuttime = maxTime;
        if (bankMan != null)
        {
            bankMan.timertxt.text = cuttime.ToString();
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (cuttime > 0)
        {
            yield return new WaitForSeconds(1);
            cuttime--;
            if (bankMan != null)
            {
                bankMan.timertxt.text = cuttime.ToString();
            }
        }

        if (bankMan != null)
        {
            bankMan.TimerEnded();
        }
        playerControler.coins += 110;
        Destroy(gameObject);
    }
    private void Update()
    {
        if (bankMan != null)
        {
            bankMan.timertxt.text = cuttime.ToString();
        }
    }
}
