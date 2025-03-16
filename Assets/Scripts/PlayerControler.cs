using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 enemypos;
    private Animator animator;
    //знизу public, зверху private
    public HP_bar Hpbar;
    public int HP = 100;
    public int MaxHP = 100; 
    public float speed = 5f;
    public int hurt = 10;
    public int coins;
    public TextMeshProUGUI tcoin;
    private void Awake()
    {
        Save.GetHP();
        Save.GetCoins();
        Save.Gethurt();
        Save.Getradius();
        Save.Getspeed();
        Save.GetmaxHP();
    }
    void Start()
    {
        Hpbar = GameObject.Find("HP_bar").GetComponent<HP_bar>();
        MaxHP=Save.maxHP;
        speed = Save.speed;
        Hpbar.maxHP = MaxHP;        
        HP = Save.HP;
        updateHp();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   
        coins = Save.coins;      
        updateCoin();
        hurt = Save.hurt;
        transform.GetChild(1).localScale= new Vector3(Save.radius, Save.radius, 0);
        speed = Save.speed; 
    }

    void Update()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;

        if (rb2d.velocity!= Vector2.zero )
        {
            animator.Play("Walk");
        }    
        Camera.main.gameObject.transform.position = new Vector3(transform.position.x,transform.position.y,-10);
        updateCoin();
        updateHp();

    }
    private void updateHp()
    {
        
        Save.SaveHP(HP);
        Hpbar.UpdateBar(HP);
        Hpbar.maxHP=MaxHP;
    }
    private void updateCoin()
    {
        tcoin.text = coins + "";
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, enemypos - transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            
            enemypos=collision.gameObject.transform.position;
            Vector2 forceto = new Vector2(transform.position.x, transform.position.y) - new Vector2(enemypos.x, enemypos.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forceto*-10,ForceMode2D.Impulse);
            HP -= collision.gameObject.GetComponent<EnemyControler>().hurt;
            updateHp();
            animator.Play("Hurt");
            if(HP <=0)
            {
                HP = MaxHP;
                SceneManager.LoadScene(1);
                if(coins>100)
                {
                    coins = 100;
                    Save.coins = coins;
                    Save.SaveHP(MaxHP);
                }

            }
        }
    }
}

