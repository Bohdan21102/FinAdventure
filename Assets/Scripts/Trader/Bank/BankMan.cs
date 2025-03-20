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
            timertxt.text = FindObjectOfType<BankTimer>().cuttime.ToString();
        }
        else
        {
            activeButton.interactable = true;
        }
        UpdateShopState();
    }

    public void ActivateTimer()
    {

        if (activeButton != null)
        {
            activeButton.interactable = false;
        }
    }

    private void SetButtons()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            {
                if (button.gameObject.name == "Close") button.onClick.AddListener(HideShop);
                if (button.gameObject.name == "MakeDeposit") button.onClick.AddListener(TakeLoan);
            }

        }
    }
}