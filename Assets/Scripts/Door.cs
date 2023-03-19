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

    public int doorPrice;
    public int doorsOpened;

    public bool roomOneUnlocked;
    public bool roomTwoUnlocked;
    public bool roomTwoAUnlocked;
    public bool roomThreeUnlocked;
    public bool roomThreeAUnlocked;
    public bool roomFourUnlocked;
    public bool roomTunnelUnlocked;

    public bool navigationUnlocked;
    public bool communicationUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        doorButton1.gameObject.SetActive(false);
        

        roomTwoUnlocked = false;
        roomTwoAUnlocked = false;
        roomThreeUnlocked = false;
        roomThreeAUnlocked = false;
        roomFourUnlocked = false;
        roomTunnelUnlocked = false;

        navigationUnlocked = false;
        communicationUnlocked = false; 
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
    public void Door12a()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door1-2a");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            roomTwoAUnlocked = true;
            
        }
    }
    public void Door2aTunnel()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door2a-Tunnel");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            roomTunnelUnlocked = true;
            
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
            roomThreeUnlocked = true;
            
        }
    }
    public void Door2a3a()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door2a-3a");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            roomThreeAUnlocked = true;
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
            roomFourUnlocked = true;
        }
    }
    public void Door3a4()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3a-4");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            
        }
    }
    public void Door3Tunnel()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3-Tunnel");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;

        }
    }

    public void Door3aComms()
    {
        if (player.currentCurrency >= doorPrice )
        {
            door = GameObject.Find("Door3a-Comms");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            
        }
    }
    public void DoorTunnelComms()
    {
        if (player.currentCurrency >= doorPrice && roomThreeUnlocked == true)
        {
            door = GameObject.Find("DoorTunnel-Comms");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
           
        }
    }
    public void DoorTunnelNav()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("DoorTunnel-Nav");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            
        }
    }
    


}
