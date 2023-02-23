using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject enemy;
    private GameObject enemyClone;
    

    private Transform target;


    //private int minDistance = 1;
    //private int maxDistance = 10;

    public float enemySpeed = 7;
    public float enemyCollisionDamage = 5;

    [HideInInspector]
    public Player playerScript;

   

    // Start is called before the first frame update
    void Start()
    {

        rb = enemy.GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMovement();

    }

    

    public void EnemyMovement()
    {
       
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if(gameObject.name == "Enemy(Clone)")
            {
                Destroy(gameObject);
                
            }

        }

        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }



}








