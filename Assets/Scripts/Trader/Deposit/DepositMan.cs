using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class DepositMan : MonoBehaviour
{
    public bool isPlayerThere = false;
    public GameObject shop;
    public PlayerControler player;
    public TextMeshProUGUI timertxt;
    public GameObject timerPrefab;
    private Button activeButton;

    private void Start()
    {

        activeButton = GameObject.Find("MakeDeposit").GetComponent<Button>();
        shop.SetActive(false);
    }

    public void UpdateShopState()
    {
        shop.SetActive(isPlayerThere);
    }

    public void MakeDeposit()
    {
        player.coins -= 100;
        activeButton = GameObject.Find("MakeDeposit").GetComponent<Button>();

        GameObject timerObj = Instantiate(timerPrefab, transform.position, Quaternion.identity);
        DepositTimer timerScript = timerObj.GetComponent<DepositTimer>();
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
        if (FindObjectOfType<DepositTimer>() != null)
        {
            activeButton.interactable = false;
            timertxt.text = FindObjectOfType<DepositTimer>().cuttime.ToString();
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
                if (button.gameObject.name == "MakeDeposit") button.onClick.AddListener(MakeDeposit);
            }

        }
    }
}