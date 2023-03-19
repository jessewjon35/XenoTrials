using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    //public Rigidbody2D rb;

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
    //private CircleCollider2D meleeCollider;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        //projectileClone = GameObject.FindGameObjectWithTag("Projectile");

        playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        //meleeCollider = GameObject.FindGameObjectWithTag("Melee").GetComponent<CircleCollider2D>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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

        if(collision.gameObject.tag == "Melee")
        {

            speed *= -1;

        }

        if(collision.gameObject.tag == "Enemy")
        {
            if(speed < 0)
            {
                Destroy(gameObject);
                enemyHealth.enemy1CurrentHealth -= projectileDamage;
                playerScript.currentCurrency += ricochetCurrency;
                enemyScript.KillEnemy();
            }
        }
              

        if(collision.gameObject.tag == "walls ")
        {
            DestroyProjectile();
        }
        if(collision.gameObject.tag == "floor")
        {
            DestroyProjectile();
        }    
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
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

        

        if(collision.gameObject.tag == "walls " || collision.gameObject.tag == "floor")
        {
            DestroyProjectile();
        } 
    }*/


}
