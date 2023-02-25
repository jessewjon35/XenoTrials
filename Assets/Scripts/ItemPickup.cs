using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    public Player player;
    public PlayerUI playerUi;

    private GameObject moneyItem;

    public float currencyAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moneyItem = GameObject.FindWithTag("currency");

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "currency")
        {
            Destroy(obj: moneyItem);
            player.currentCurrency = player.currentCurrency += currencyAmount;
            playerUi.SetCurrency();
        }
        
    }

}
