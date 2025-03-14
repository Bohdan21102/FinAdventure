using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankMan : MonoBehaviour
{
    public bool isPlayerThere = false;
    public GameObject shop;
    public PlayerControler player;
    public TextMeshProUGUI timertxt;
    public GameObject timerPrefab;
    private Button activeButton;
    private bool isTimerActive = false;

    private void Start()
    {
        activeButton = GameObject.Find("TakeLoan").GetComponent<Button>();
        shop.SetActive(false);

    }

    public void UpdateShopState()
    {
        shop.SetActive(isPlayerThere);
    }

    public void TakeLoan()
    {
        player.coins += 1000;
        activeButton = GameObject.Find("MakeDeposit").GetComponent<Button>();

        GameObject timerObj = Instantiate(timerPrefab, transform.position, Quaternion.identity);
        BankTimer timerScript = timerObj.GetComponent<BankTimer>();
        timerScript.Initialize(this);
    }

    public void TimerEnded()
    {
        isTimerActive = false;

        if (activeButton != null)
        {
            activeButton.interactable = true;
            activeButton = null;
        }
    }

    public void HideShop()
    {
        isPlayerThere = false;
        UpdateShopState();
    }

    public void ShowShop()
    {
        isPlayerThere = true;
        UpdateShopState();
    }

    private void Update()
    {
        if (FindObjectOfType<BankTimer>() != null)
        {
            activeButton.interactable = false;
            timertxt.text= FindObjectOfType<BankTimer>().cuttime.ToString();
        }
        else
        {
            activeButton.interactable = true;
        }
        UpdateShopState();
        
        
       
    }
    public void ActivateTimer()
    {
        isTimerActive = true;
        if (activeButton != null)
        {
            activeButton.interactable = false;
        }
    }
}
