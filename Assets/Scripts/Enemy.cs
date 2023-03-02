using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject enemy;
    //private GameObject enemyClone;
    public GameObject currency;
    

    private Transform target;
    


    //private int minDistance = 1;
    //private int maxDistance = 10;

    public float enemySpeed = 7;
    public float enemyCollisionDamage = 5;
    public float dropChance = .75f;
    

    public float enemy1CurrentHealth;
    private float enemy1MinHealth = 0f;
    private float enemy1MaxHealth = 10;
    
   

    
    public Player playerScript;
    public Pistol pistol;
    public Shotgun shotgun;
   





    // Start is called before the first frame update
    void Start()
    {

        rb = enemy.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemy1CurrentHealth = enemy1MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        

        EnemyMovement();
        
        if(enemy1CurrentHealth <= enemy1MinHealth)
        {
            enemy1CurrentHealth = enemy1MinHealth;
        }
        
       

    }

    

    public void EnemyMovement()
    {
       
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        
        
        
    }


    public void DropRate()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            Instantiate(currency, this.transform.position, Quaternion.identity);
        }
    }

    public void KillEnemy()
    {
        if(enemy1CurrentHealth <= enemy1MinHealth)
        {
            Destroy(gameObject);
            DropRate();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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

            Debug.Log(enemy1CurrentHealth);
            KillEnemy();
            enemy1CurrentHealth -= pistol.pistolDamage;

        }
        if (collision.gameObject.tag == "Pellets")
        {

            Debug.Log(enemy1CurrentHealth);
            KillEnemy();
            enemy1CurrentHealth -= shotgun.shotgunDamage;
        }

    }

   



}








