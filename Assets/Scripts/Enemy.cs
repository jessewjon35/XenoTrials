using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject enemy;
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject enemyProjectile;
    public GameObject sealer;

    public float timeBetweenShots;
    public float startTimeBetweenShots;
    
    public ParticleSystem enemyDeathEffect;

    private Transform target;

    //private int minDistance = 1;
    //private int maxDistance = 10;

    public int enemySpeed = 5;
    public int enemyCollisionDamage = 5;
    public float dropChance = .75f;

    
     public EnemyHealth enemyHealth;

     public Player playerScript;    
     public Pistol pistol;
     public Shotgun shotgun;
     public EnemyProjectile enemyProjectileScript;
     public Melee melee;
     public WaveManager waveManager;

    public Renderer rd;
    private BoxCollider2D playerCollider;
    private CircleCollider2D starterMeleeCollider;
    private CircleCollider2D enemy1Collider;
    public CircleCollider2D projectileCollider;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        rb = enemy.GetComponent<Rigidbody2D>();
        
        enemy1Collider = GetComponent<CircleCollider2D>();
        GetComponent<CircleCollider2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pistol = GameObject.FindGameObjectWithTag("Player").GetComponent<Pistol>();
        shotgun = GameObject.FindGameObjectWithTag("Player").GetComponent<Shotgun>();
        //enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();

        melee = GameObject.FindGameObjectWithTag("Melee").GetComponent<Melee>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        starterMeleeCollider = GameObject.FindGameObjectWithTag("Melee").GetComponent<CircleCollider2D>();
       
        
        

        timeBetweenShots = startTimeBetweenShots;

        

        
    }

    // Update is called once per frame
    void Update()
    {


        //EnemyMovement();

        /*
        
        if(timeBetweenShots <= 0 && rd.isVisible == true)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }*/

        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100f);
        Debug.DrawRay(hit.transform.position, transform.right, Color.red);*/
        


        if(timeBetweenShots <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

        

    }

    private void FixedUpdate()
    {
        
    }


    public void DropRate()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            Instantiate(sealer, this.transform.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == playerCollider)
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                Destroy(gameObject);

            }
        }
 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Melee")
        {
            enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.enemy1CurrentHealth -= melee.meleeDamage;
            playerScript.currentCurrency += melee.currencyPerMelee;

        }

    }


    


}








