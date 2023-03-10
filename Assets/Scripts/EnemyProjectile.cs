using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public Player playerScript;
    public PlayerUI playerUi;

    public float speed;
    public float projectileDamage;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DestroyProjectile();
            playerScript.currentHealth -= projectileDamage;
            playerUi.SetHealth();

        }
    }

}
