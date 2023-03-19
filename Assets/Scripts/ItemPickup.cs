using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    
    public Player player;
       
    public PlayerUI playerUi;

    private GameObject sealerClone;

    public int currencyAmount = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sealerClone = GameObject.FindWithTag("SpawnerSealer");


        

    }

    public void CurrencyCheat()
    {
        
            player.currentCurrency += currencyAmount;
            playerUi.SetCurrency();
        
    }
    
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "SpawnerSealer")
            {
                Destroy(obj: sealerClone);
                player.currentSealer += 1;
                playerUi.SetSealer();

            }
        
    }

}
