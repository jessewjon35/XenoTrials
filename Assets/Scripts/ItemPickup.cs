using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    
    public Player player;
       
    public PlayerUI playerUi;

    private GameObject currencyClone;

    public float currencyAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyClone = GameObject.FindWithTag("currency");


        

    }

    public void CurrencyCheat()
    {
        
            player.currentCurrency += currencyAmount;
            playerUi.SetCurrency();
        
    }
    
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "currency")
            {
                Destroy(obj: currencyClone);
                player.currentCurrency += currencyAmount;
                playerUi.SetCurrency();

            }
        
    }

}
