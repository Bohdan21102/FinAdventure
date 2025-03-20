using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 enemyPos;
    private Animator animator;

    public HP_bar Hpbar;
    public int HP = 100;
    public int MaxHP = 100;
    public float speed = 5f;
    public int hurt = 10;
    public int coins;
    public TextMeshProUGUI tcoin;

    private void Awake()
    {
        LoadPlayerData();
    }

    void Start()
    {
        InitializePlayer();
    }

    void Update()
    {
        HandleMovement();
        UpdateCameraPosition();
        UpdateUI();
    }

    private void LoadPlayerData()
    {
        Save.GetHP();
        Save.GetCoins();
        Save.Gethurt();
        Save.Getradius();
        Save.Getspeed();
        Save.GetmaxHP();
    }

    private void InitializePlayer()
    {
        Hpbar = GameObject.Find("HP_bar").GetComponent<HP_bar>();
        MaxHP = Save.maxHP;
        speed = Save.speed;
        Hpbar.maxHP = MaxHP;
        HP = Save.HP;
        UpdateHP();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coins = Save.coins;
        UpdateCoin();
        hurt = Save.hurt;
        transform.GetChild(1).localScale = new Vector3(Save.radius, Save.radius, 0);
    }

    private void HandleMovement()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;

        if (rb2d.velocity != Vector2.zero)
        {
            animator.Play("Walk");
        }
    }

    private void UpdateCameraPosition()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    private void UpdateUI()
    {
        UpdateCoin();
        UpdateHP();
    }

    private void UpdateHP()
    {
        Save.SaveHP(HP);
        Hpbar.UpdateBar(HP);
        Hpbar.maxHP = MaxHP;
    }

    private void UpdateCoin()
    {
        tcoin.text = coins.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HandleEnemyCollision(collision);
        }
    }

    private void HandleEnemyCollision(Collision2D collision)
    {
        enemyPos = collision.gameObject.transform.position;
        Vector2 forceTo = new Vector2(transform.position.x, transform.position.y) - new Vector2(enemyPos.x, enemyPos.y);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forceTo * -10, ForceMode2D.Impulse);
        HP -= collision.gameObject.GetComponent<EnemyControler>().hurt;
        UpdateHP();
        animator.Play("Hurt");
        CheckPlayerDeath();
    }

    private void CheckPlayerDeath()
    {
        if (HP <= 0)
        {
            HP = MaxHP;
            SceneManager.LoadScene(1);
            if (coins > 100)
            {
                coins = 100;
                Save.coins = coins;
                Save.SaveHP(MaxHP);
            }
        }
    }
}