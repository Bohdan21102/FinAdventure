using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DepositMan : MonoBehaviour
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
        activeButton = GameObject.Find("MakeDeposit").GetComponent<Button>();
        shop.SetActive(false);

    }

    public void UpdateShopState()
    {
        shop.SetActive(isPlayerThere);
    }

    public void Buy(Button baton)
    {
        player.coins -= 100 ;
        activeButton = baton;

        // Якщо є таймер, кнопка не активна
        

        // Створюємо таймер
        GameObject timerObj = Instantiate(timerPrefab, transform.position, Quaternion.identity);
        DepositTimer timerScript = timerObj.GetComponent<DepositTimer>();
        timerScript.Initialize(this);
    }

    public void TimerEnded()
    {
        // Коли таймер закінчився, дозволяємо натискати кнопку знову
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

    // Оновлення для перевірки таймера в методі Update
    private void Update()
    {
        if (FindObjectOfType<DepositTimer>() != null)
        {
            activeButton.interactable = false;
            timertxt.text= FindObjectOfType<DepositTimer>().cuttime.ToString();
        }
        else
        {
            activeButton.interactable = true;
        }
        UpdateShopState();
        
        
       
    }

    // Метод для активації таймера
    public void ActivateTimer()
    {
        isTimerActive = true;
        if (activeButton != null)
        {
            activeButton.interactable = false;
        }
    }
}
