using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public Rigidbody2D rb;

    public Player playerScript;
    public PlayerUI playerUi;
    public EnemyHealth enemyHealth;
    public Enemy enemyScript;

    //private GameObject projectileClone;

    public float speed;
    public int projectileDamage = 25;
    public int ricochetCurrency = 30;

    private Transform player;
    private Transform enemy;
    private Vector2 target;
    private Vector2 ricochetTarget;

    public CircleCollider2D enemy1Collider;
    public BoxCollider2D playerCollider;
    public CircleCollider2D meleeCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        enemy1Collider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CircleCollider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        meleeCollider = GameObject.FindGameObjectWithTag("Melee").GetComponent<CircleCollider2D>();

        target = new Vector2(player.position.x, player.position.y);
        ricochetTarget = new Vector2(enemy.position.x, enemy.position.y);
    }

    // Update is called once per frame
    void Update()
    {        
        ProjectileMovement();

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    public void ProjectileMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void ProjectileRicochet()
    {

        transform.position = Vector2.MoveTowards(transform.position, ricochetTarget, speed * Time.deltaTime);
        
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(playerScript.isInvincible == true)
            {
                DestroyProjectile();
            }
            else if(playerScript.isInvincible == false)
            {
                DestroyProjectile();
                playerScript.currentHealth -= projectileDamage;
                playerUi.SetHealth();
            }
 
        }

        if(other.gameObject.tag == "Melee")
        {
            if(gameObject.name != "StarterMelee")
            {
                speed *= -1;
            }
        }

        if (other.CompareTag("Enemy"))
        {
            if(speed < 0)
            {
                enemyHealth = other.GetComponent<EnemyHealth>();
                enemyHealth.enemy1CurrentHealth -= projectileDamage;
                playerScript.currentCurrency += ricochetCurrency;
                DestroyProjectile();
            }
                        
        }

        if (other.gameObject.tag == "walls")
        {
            DestroyProjectile();
        }
        if(other.gameObject.tag == "floor")
        {
            DestroyProjectile();
        }    
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == playerCollider)
        {
            if (playerScript.isInvincible == true)
            {
                DestroyProjectile();
            }
            else if (playerScript.isInvincible == false)
            {
                DestroyProjectile();
                playerScript.currentHealth -= projectileDamage;
                playerUi.SetHealth();
            }

        }

        if (other.gameObject.tag == "Melee")
        {

            speed *= -1;
            
            
        }
        

        if (other.gameObject.tag == "Enemy")
        {
            if (speed < 0)
            {
                DestroyProjectile();
            }

        }

        if (other.gameObject.tag == "walls ")
        {
            DestroyProjectile();
        }
        if (other.gameObject.tag == "floor")
        {
            DestroyProjectile();
        }
    }*/



}
