using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objectives : MonoBehaviour
{
    public Player player;
    public Shop shop;
    public Portal portal;
    public Timer timer;

    public GameObject communicationPanel;
    public GameObject navigationPanel;

    public int communicationSabotagePrice;
    public int navigationSabotagePrice;

    public bool communicationRepaired;
    public bool navigationRepaired;

    public bool communicationSabotaged;
    public bool navigationSabotaged;

    public Button navigationRepairButton;
    public Button navigationSabotageButton;
    public Button communicationRepairButton;
    public Button communicationSabotageButton;

    

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Shop>();
        portal = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>();

        navigationRepairButton.gameObject.SetActive(false);
        navigationSabotageButton.gameObject.SetActive(false);
        communicationRepairButton.gameObject.SetActive(false);
        communicationSabotageButton.gameObject.SetActive(false);

        communicationRepaired = false;
        communicationSabotaged = false;

        navigationRepaired = false;
        navigationSabotaged = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(navigationRepaired == true)
        {
            portal.portalActivated = true;   
        }

        if(navigationSabotaged == true && communicationSabotaged == true)
        {
            timer.timerStarted = true;
            timer.timerText.gameObject.SetActive(true);
        }
        
    
    }

    public void RepairCommunication()
    {
        if(shop.communicationPartsBought == true && communicationRepaired == false)
        {
            communicationRepaired = true;
        }
        else
        {

        }
    }

    public void SabotageCommunication()
    {
        if(communicationRepaired == true && player.currentCurrency >= communicationSabotagePrice)
        {
            player.currentCurrency -= communicationSabotagePrice;
            communicationSabotaged = true;
        }
        else
        {

        }
    }

    public void RepairNavigation()
    {
        if (shop.navigationPartsBought == true && navigationRepaired == false)
        {
            navigationRepaired = true;
        }
        else
        {

        }
    }

    public void SabotageNavigation()
    {
        if (navigationRepaired == true && player.currentCurrency >= navigationSabotagePrice)
        {
            player.currentCurrency -= navigationSabotagePrice;
            navigationSabotaged = true;
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "Communication")
            {
                if(communicationRepaired == false && communicationSabotaged == false)
                {
                    communicationRepairButton.gameObject.SetActive(true);
                    communicationSabotageButton.gameObject.SetActive(false);
                }
                else if(communicationRepaired == true && communicationSabotaged == false)
                {
                    communicationRepairButton.gameObject.SetActive(false);
                    communicationSabotageButton.gameObject.SetActive(true);
                }
                else
                {
                    communicationRepairButton.gameObject.SetActive(false);
                    communicationSabotageButton.gameObject.SetActive(false);
                }
            }

            if(gameObject.name == "Navigation")
            {
                if (navigationRepaired == false && navigationSabotaged == false)
                {
                    navigationRepairButton.gameObject.SetActive(true);
                    navigationSabotageButton.gameObject.SetActive(false);
                }
                else if (navigationRepaired == true && navigationSabotaged == false)
                {
                    navigationRepairButton.gameObject.SetActive(false);
                    navigationSabotageButton.gameObject.SetActive(true);
                }
                else
                {
                    navigationRepairButton.gameObject.SetActive(false);
                    navigationSabotageButton.gameObject.SetActive(false);
                }
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            navigationRepairButton.gameObject.SetActive(false);
            navigationSabotageButton.gameObject.SetActive(false);
            communicationRepairButton.gameObject.SetActive(false);
            communicationSabotageButton.gameObject.SetActive(false);
        }
    }

}
