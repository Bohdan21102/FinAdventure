using System.Collections;
using UnityEngine;

public class BankTimer : MonoBehaviour
{
    public BankMan bankMan;
    private PlayerControler playerControler;

    public int cuttime;
    private int maxTime = 100;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize(BankMan bankManRef)
    {
        bankMan = bankManRef;
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
