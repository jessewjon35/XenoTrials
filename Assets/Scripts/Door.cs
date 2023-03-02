using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{

    private GameObject door;

    public Button doorButton1;
   


    [SerializeField]
    private Player player;
    [SerializeField]
    private PlayerUI playerUi;

    public float doorPrice;
    public int doorsOpened;

    public bool doorOneUnlocked;
    public bool doorEightUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        doorButton1.gameObject.SetActive(false);
        

        doorOneUnlocked = false;
        doorEightUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            doorButton1.gameObject.SetActive(true);

        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            doorButton1.gameObject.SetActive(false);
           
        }
    }

    public void Door12()
    {
        if(player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door1-2");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            doorOneUnlocked = true;
        }
    }
    public void Door23()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door2-3");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

           
        }
    }
    public void Door34()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3-4");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

        }
    }
    public void Door3a()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3a");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

           
        }
    }
    public void Door45()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door4-5");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door56()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door5-6");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door67()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door6-7");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door6a()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door6a");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door6b()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door6b");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door78()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door7-8");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            
        }
    }
    public void Door81()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door8-1");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorEightUnlocked = true;
        }
    }


}
