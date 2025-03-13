using System.Collections;
using UnityEngine;

public class DepositTimer : MonoBehaviour
{
    public DepositMan depMan;
    private PlayerControler playerControler;

    public int cuttime;
    private int maxTime = 300;

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
        if (depMan != null)
        {
            depMan.timertxt.text = cuttime.ToString();
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (cuttime > 0)
        {
            yield return new WaitForSeconds(1);
            cuttime--;
            if (depMan != null)
            {
                depMan.timertxt.text = cuttime.ToString();
            }
        }

        if (depMan != null)
        {
            depMan.TimerEnded();
        }
        playerControler.coins += 110;
        Destroy(gameObject);
    }
    private void Update()
    {
        if (depMan != null)
        {
            depMan.timertxt.text = cuttime.ToString();
        }
    }
}
