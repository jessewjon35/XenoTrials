using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //public Rigidbody2D rb;

    public GameObject enemy;
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject enemyProjectile;
    public GameObject sealer;

    public float timeBetweenShots;
    public float startTimeBetweenShots;
    
    //private GameObject enemyClone;
    

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
    //private PlayerUI playerUi;

    public Renderer rd;
    private BoxCollider2D playerCollider;
    private CircleCollider2D starterMeleeCollider;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        //rb = enemy.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pistol = GameObject.FindGameObjectWithTag("Player").GetComponent<Pistol>();
        shotgun = GameObject.FindGameObjectWithTag("Player").GetComponent<Shotgun>();
        melee = GameObject.FindGameObjectWithTag("Melee").GetComponent<Melee>();
        //playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();

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

    public void KillEnemy()
    {
        if(enemyHealth.enemy1CurrentHealth <= enemyHealth.enemy1MinHealth)
        {
            Destroy(gameObject);

            //Instantiate(enemyDeathEffect, transform.position, transform.rotation);

            DropRate();
            
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

        if (collision.collider == starterMeleeCollider)
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                enemyHealth.enemy1CurrentHealth -= melee.meleeDamage;
                playerScript.currentCurrency += melee.currencyPerMelee;
            }

        }

    }





}








