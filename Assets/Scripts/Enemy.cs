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

    public GameObject enemyProjectile;
    public float timeBetweenShots;
    public float startTimeBetweenShots;
    
    //private GameObject enemyClone;
    //public GameObject currency;

    public ParticleSystem enemyDeathEffect;

    private Transform target;

    //private int minDistance = 1;
    //private int maxDistance = 10;

    public int enemySpeed = 5;
    public int enemyCollisionDamage = 5;
    //public float dropChance = .75f;
    
    

    public int enemy1CurrentHealth;
    private int enemy1MinHealth = 0;
    private int enemy1MaxHealth = 50;
    
   

    
     public Player playerScript;    
     public Pistol pistol;
     public Shotgun shotgun;
    //private PlayerUI playerUi;

    public Renderer rd;



    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        //rb = enemy.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pistol = GameObject.FindGameObjectWithTag("Player").GetComponent<Pistol>();
        shotgun = GameObject.FindGameObjectWithTag("Player").GetComponent<Shotgun>();
        //playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();

        enemy1CurrentHealth = enemy1MaxHealth;

        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        

        //EnemyMovement();
        
        if(enemy1CurrentHealth <= enemy1MinHealth)
        {
            enemy1CurrentHealth = enemy1MinHealth;
        }
        
        if(timeBetweenShots <= 0 && rd.isVisible == true)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }

    

    /*public void EnemyMovement()
    {
       
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        
        
        
    }*/


    /*public void DropRate()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            Instantiate(currency, this.transform.position, Quaternion.identity);
        }
    }*/

    public void KillEnemy()
    {
        if(enemy1CurrentHealth <= enemy1MinHealth)
        {
            Destroy(gameObject);

            Instantiate(enemyDeathEffect, transform.position, transform.rotation);

            //DropRate();
            
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                Destroy(gameObject);

            }
        }

            
        if(collision.gameObject.tag == "Bullet")
        {
            if(gameObject.name == "Enemy(Clone)")
            { 
                enemy1CurrentHealth -= pistol.pistolDamage;
                playerScript.currentCurrency += pistol.pistolCurrencyPerHit;
                
                Debug.Log(enemy1CurrentHealth);
                KillEnemy();

            }
  
            

        }


        if (collision.gameObject.tag == "Pellets")
        {
            if(gameObject.name == "Enemy(Clone)")
            {
                enemy1CurrentHealth -= shotgun.shotgunDamage;
                playerScript.currentCurrency += pistol.pistolCurrencyPerHit;

                Debug.Log(enemy1CurrentHealth);
                KillEnemy();
            }  
            
        }

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                Destroy(gameObject);

            }
        }


        if (collision.gameObject.tag == "Bullet")
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                enemy1CurrentHealth -= pistol.pistolDamage;
                playerScript.currentCurrency += pistol.pistolCurrencyPerHit;

                Debug.Log(enemy1CurrentHealth);
                KillEnemy();

            }



        }


        if (collision.gameObject.tag == "Pellets")
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                enemy1CurrentHealth -= shotgun.shotgunDamage;
                playerScript.currentCurrency += pistol.pistolCurrencyPerHit;

                Debug.Log(enemy1CurrentHealth);
                KillEnemy();
            }

        }
    }





}








