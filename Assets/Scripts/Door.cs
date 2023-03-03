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

    public bool roomOneUnlocked;
    public bool roomTwoUnlocked;
    public bool roomThreeUnlocked;
    public bool roomFourUnlocked;
    public bool roomFiveUnlocked;
    public bool roomSixUnlocked;
    public bool roomSixaUnlocked;
    public bool roomSixbUnlocked;
    public bool roomSevenUnlocked;
    public bool roomEightUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        doorButton1.gameObject.SetActive(false);
        

        roomTwoUnlocked = false;
        roomThreeUnlocked = false;
        roomFourUnlocked = false;
        roomFiveUnlocked = false;
        roomSixUnlocked = false;
        roomSixaUnlocked = false;
        roomSixbUnlocked = false;
        roomSevenUnlocked = false;
        roomEightUnlocked = false;

        
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
            roomTwoUnlocked = true;
            
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

            doorsOpened++;
            roomTwoUnlocked = true;
            roomThreeUnlocked = true;
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

            doorsOpened++;
            roomThreeUnlocked = true;
            roomFourUnlocked = true;
            
        }
    }
    public void Door3a()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3a-3");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            roomThreeUnlocked = true;
            
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

            doorsOpened++;
            roomFourUnlocked = true;
            roomFiveUnlocked = true;
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

            doorsOpened++;
            roomFiveUnlocked = true;
            roomSixUnlocked = true;
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

            doorsOpened++;
            roomSixUnlocked = true;
            roomSevenUnlocked = true;
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

            doorsOpened++;
            roomSixUnlocked = true;
            roomSixaUnlocked = true;
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

            doorsOpened++;
            roomSixaUnlocked = true;
            roomSixbUnlocked = true;
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

            doorsOpened++;
            roomSevenUnlocked = true;
            roomEightUnlocked = true;
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

            doorsOpened++;
            roomEightUnlocked = true;
        }
    }


}
