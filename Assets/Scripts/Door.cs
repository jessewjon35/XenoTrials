using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Door : MonoBehaviour
{

    private GameObject door;

    public Button doorButton;
   


    [SerializeField]
    private Player player;
    [SerializeField]
    private PlayerUI playerUi;
    [SerializeField]
    private Shop shop;
    [SerializeField]
    private Objectives objectives;

    public int doorPrice;
    public int doorsOpened;

    public bool roomTwoUnlocked;
    public bool roomTwoAUnlocked;
    public bool roomThreeUnlocked;
    public bool roomThreeAUnlocked;
    public bool roomFourUnlocked;
    public bool room2aVentUnlocked;
    public bool room3VentUnlocked;
    public bool room3aVentUnlocked;
    public bool ventsUnlocked;

    public bool navigationUnlocked;
    public bool communicationUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        objectives = GameObject.FindGameObjectWithTag("Objectives").GetComponent<Objectives>();

        doorButton.gameObject.SetActive(false);
        

        roomTwoUnlocked = false;
        roomTwoAUnlocked = false;
        roomThreeUnlocked = false;
        roomThreeAUnlocked = false;
        roomFourUnlocked = false;
        room2aVentUnlocked = false;
        room3VentUnlocked = false;
        room3aVentUnlocked = false;
        ventsUnlocked = false;

        navigationUnlocked = false;
        communicationUnlocked = false; 
    }

    // Update is called once per frame
    void Update()
    {
      
        if(room2aVentUnlocked == true && room3aVentUnlocked == true && room3VentUnlocked == true)
        {
            ventsUnlocked = true;
        }

        if(objectives.communicationRepaired == true)
        {
            door = GameObject.Find("Door2a-Tunnel");
            Destroy(door);

            door = GameObject.Find("Door3-Tunnel");
            Destroy(door);

            door = GameObject.Find("Door3a-Comms");
            Destroy(door);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            doorButton.gameObject.SetActive(true);

        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            doorButton.gameObject.SetActive(false);
           
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
        if (shop.ventPartsBought == true)
        {
            door = GameObject.Find("Door2a-Tunnel");
            Destroy(door);

            doorsOpened++;
            shop.ventPartsBought = false;
            room2aVentUnlocked = true;            
            
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
            roomTwoUnlocked = true;
            
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
            roomTwoAUnlocked = true;
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
    public void Door3a4()
    {
        if (player.currentCurrency >= doorPrice)
        {
            door = GameObject.Find("Door3a-4");
            Destroy(door);
            player.currentCurrency -= doorPrice;
            playerUi.SetCurrency();

            doorsOpened++;
            roomThreeAUnlocked = true;
            roomFourUnlocked = true;
            
        }
    }
    public void Door3Tunnel()
    {
        if (shop.ventPartsBought == true)
        {
            door = GameObject.Find("Door3-Tunnel");
            Destroy(door);
            

            doorsOpened++;
            shop.ventPartsBought = false;
            roomThreeUnlocked = true;
            room3VentUnlocked = true;

        }
    }

    public void Door3aComms()
    {
        if (shop.ventPartsBought == true && communicationUnlocked == true)
        {
            door = GameObject.Find("Door3a-Comms");
            Destroy(door);
            

            doorsOpened++;
            shop.ventPartsBought = false;
            room3aVentUnlocked = true;
            communicationUnlocked = true;
            roomThreeAUnlocked = true;
            
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
            communicationUnlocked = true;
           
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
            navigationUnlocked = true;
            
        }
    }
    


}
