using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Player player;
    public PlayerController playerController;
    public PlayerUI playerUi;
    public Door door;

    public Button shopButton;

    public Button knifeButton;
    public Button swordButton;
    public Button maceButton;
    public Button ventButtonText;
    public Button navRepairButton;
    public Button commRepairButton;

    public GameObject shopPanel;

    public TMP_Text knifeText;
    public TMP_Text swordText;
    public TMP_Text maceText;

    public TMP_Text ventPartsText;
    public TMP_Text navRepairPlaceholderText;
    public TMP_Text commRepairPlaceholderText;
    public TMP_Text navRepairPartsText;
    public TMP_Text commRepairPartsText;

    public int knifePrice;
    public int swordPrice;
    public int macePrice;
    public int ventPartsPrice;
    public int navigationPartsPrice;
    public int communicationPartsPrice;

    public bool knifeBought;
    public bool swordBought;
    public bool maceBought;
    public bool ventPartsBought;
    public bool navigationPartsBought;
    public bool communicationPartsBought;
    

    

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();

        shopPanel.SetActive(false);

        knifeText.gameObject.SetActive(true);
        swordText.gameObject.SetActive(true);
        maceText.gameObject.SetActive(true);

        knifeButton.gameObject.SetActive(true);
        swordButton.gameObject.SetActive(true);
        maceButton.gameObject.SetActive(true);

        ventPartsText.gameObject.SetActive(false);
        navRepairPartsText.gameObject.SetActive(false);
        commRepairPartsText.gameObject.SetActive(false);

        ventButtonText.gameObject.SetActive(false);
        navRepairButton.gameObject.SetActive(false);
        commRepairButton.gameObject.SetActive(false);
        navRepairPlaceholderText.gameObject.SetActive(false);
        commRepairPlaceholderText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void WeaponsPage()
    {
        knifeText.gameObject.SetActive(true);
        swordText.gameObject.SetActive(true);
        maceText.gameObject.SetActive(true);

        knifeButton.gameObject.SetActive(true);
        swordButton.gameObject.SetActive(true);
        maceButton.gameObject.SetActive(true);

        ventPartsText.gameObject.SetActive(false);
        navRepairPartsText.gameObject.SetActive(false);
        commRepairPartsText.gameObject.SetActive(false);

        ventButtonText.gameObject.SetActive(false);
        navRepairButton.gameObject.SetActive(false);
        commRepairButton.gameObject.SetActive(false);
        navRepairPlaceholderText.gameObject.SetActive(false);
        commRepairPlaceholderText.gameObject.SetActive(false);
    }

    public void ObjectivesPage()
    {
        knifeText.gameObject.SetActive(false);
        swordText.gameObject.SetActive(false);
        maceText.gameObject.SetActive(false);

        knifeButton.gameObject.SetActive(false);
        swordButton.gameObject.SetActive(false);
        maceButton.gameObject.SetActive(false);

        ventPartsText.gameObject.SetActive(true);
        navRepairPartsText.gameObject.SetActive(true);
        commRepairPartsText.gameObject.SetActive(true);
        ventButtonText.gameObject.SetActive(true);
        
        if(door.communicationUnlocked == false)
        {
            commRepairButton.gameObject.SetActive(false);           
            commRepairPlaceholderText.gameObject.SetActive(true);
        }
        else if(door.communicationUnlocked == true)
        {
            commRepairButton.gameObject.SetActive(true);
            commRepairPlaceholderText.gameObject.SetActive(false);
        }

        if(door.navigationUnlocked == false)
        {
            navRepairPlaceholderText.gameObject.SetActive(true);
            navRepairButton.gameObject.SetActive(false);
        }
        else if(door.navigationUnlocked == true)
        {
            navRepairPlaceholderText.gameObject.SetActive(false);
            navRepairButton.gameObject.SetActive(true);
        }

    }

    public void BuyKnife()
    {
        if(player.currentCurrency >= knifePrice && knifeBought == false)
        {
            player.currentCurrency -= knifePrice;
            knifeBought = true;

        }
    }
    public void BuySword()
    {
        if(player.currentCurrency >= swordPrice && swordBought == false)
        {
            player.currentCurrency -= swordPrice;
            swordBought = true;
        }
    }
    public void BuyMace()
    {
        if(player.currentCurrency >= macePrice && maceBought == false)
        {
            player.currentCurrency -= macePrice;
            maceBought = true;
        }
    }

    public void BuyNavigationParts()
    {
        if(player.currentCurrency >= navigationPartsPrice && navigationPartsBought == false)
        {
            player.currentCurrency -= navigationPartsPrice;
            navigationPartsBought = true;
        }
    }
    public void BuyCommunicationParts()
    {
        if(player.currentCurrency >= communicationPartsPrice && communicationPartsBought == false)
        {
            player.currentCurrency -= communicationPartsPrice;
            communicationPartsBought = true;
        }
    }
    public void BuyVentParts()
    {
        if (player.currentCurrency >= ventPartsPrice && ventPartsBought == false || door.ventsUnlocked == false)
        {
            player.currentCurrency -= ventPartsPrice;
            ventPartsBought = true;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            shopButton.gameObject.SetActive(true);
        }        
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shopButton.gameObject.SetActive(false);
        }
            
    }

}
