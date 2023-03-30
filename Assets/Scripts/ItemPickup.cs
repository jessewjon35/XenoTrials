using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    
    public Player player;
       
    public PlayerUI playerUi;

    public BoxCollider2D playerCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        

    }

    /*public void CurrencyCheat()
    {
        
            player.currentCurrency += currencyAmount;
            playerUi.SetCurrency();
        
    }*/
    
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            /*if (collision.gameObject.tag == "SpawnerSealer")
            {
                Destroy(obj: sealerClone);
                player.currentSealer += 1;
                playerUi.SetSealer();

            }*/
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == playerCollider)
        {
            if(gameObject.name == "SpawnerSealer(Clone)")
            {
                player.currentSealer += 1;
                Destroy(gameObject);               
              
            }
        }
    }

}
