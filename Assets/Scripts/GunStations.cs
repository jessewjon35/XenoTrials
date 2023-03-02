using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunStations : MonoBehaviour
{
    public Player player;
    public Pistol pistolScript;
    public Shotgun shotgunScript;
    public PlayerUI playerUi;

    public Button pistolStationButton;
    public Button shotgunStationButton;

    public GameObject pistol;
    public GameObject shotgun;

    public float gunCost;
    public float ammoCost;

    private float pistolRefillCost;
    private float pistolRefillCount;
    private float pistolAffordableRefill;
    private float pistolAffordableRefillCost;

    private float shotgunRefillCost;
    private float shotgunRefillCount;
    private float shotgunAffordableRefill;
    private float shotgunAffordableRefillCost;

    public bool pistolBought;
    public bool shotgunBought;
  
    

    // Start is called before the first frame update
    void Start()
    {

        pistol.SetActive(false);
        shotgun.SetActive(false);
        
        pistolBought = false;
        shotgunBought = false;

        pistolStationButton.gameObject.SetActive(false);
        shotgunStationButton.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        pistolRefillCount = pistolScript.maxAmmoCapacity - pistolScript.currentAmmoCapacity + pistolScript.maxAmmoClip - pistolScript.currentAmmoClip;
        pistolRefillCost = pistolRefillCount * ammoCost;
        //Debug.Log(pistolRefillCost);

        pistolAffordableRefill = player.currentCurrency / ammoCost;
        pistolAffordableRefillCost = pistolAffordableRefill * ammoCost;


        shotgunRefillCount = shotgunScript.maxAmmoCapacity - shotgunScript.currentAmmoCapacity + shotgunScript.maxAmmoClip - shotgunScript.currentAmmoClip;
        shotgunRefillCost = shotgunRefillCount * ammoCost;
        //Debug.Log(pistolRefillCost);

        shotgunAffordableRefill = player.currentCurrency / ammoCost;
        shotgunAffordableRefillCost = shotgunAffordableRefill * ammoCost;


    }

    public void PistolPurchase()
    {
        if(player.currentCurrency >= gunCost && pistolBought == false)
        {
            pistol.SetActive(true);
            pistolBought = true;
            playerUi.pistolAmmoText.enabled = true;
            player.currentCurrency -= gunCost;

            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();
            
        }
        else if(player.currentCurrency >= pistolRefillCost && pistolBought == true && pistolScript.currentAmmoCapacity < pistolScript.maxAmmoCapacity)
        {
            pistolScript.currentAmmoCapacity = pistolScript.maxAmmoCapacity;
            pistolScript.currentAmmoClip = pistolScript.maxAmmoClip;
            player.currentCurrency -= pistolRefillCost;
            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();

        }
        else if(player.currentCurrency < pistolRefillCost && pistolBought == true && pistolScript.currentAmmoCapacity < pistolScript.maxAmmoCapacity)
        {
            pistolScript.currentAmmoCapacity += pistolAffordableRefill;
            player.currentCurrency -= pistolAffordableRefillCost;
            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();

            if(pistolScript.currentAmmoCapacity >= pistolScript.maxAmmoCapacity)
            {
                pistolScript.currentAmmoCapacity = pistolScript.maxAmmoCapacity;
            }
            else if(pistolScript.currentAmmoCapacity <= pistolScript.minAmmoCapacity)
            {
                pistolScript.currentAmmoCapacity = pistolScript.minAmmoCapacity;
            }
        }



    }

    public void ShotgunPurchase()
    {
        if (player.currentCurrency >= gunCost && shotgunBought == false)
        {
            shotgun.SetActive(true);
            shotgunBought = true;
            playerUi.shotgunAmmoText.enabled = true;
            player.currentCurrency -= gunCost;

            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

        }
        else if (player.currentCurrency >= shotgunRefillCost && shotgunBought == true && shotgunScript.currentAmmoCapacity < shotgunScript.maxAmmoCapacity)
        {
            shotgunScript.currentAmmoCapacity = shotgunScript.maxAmmoCapacity;
            shotgunScript.currentAmmoClip = shotgunScript.maxAmmoClip;
            player.currentCurrency -= shotgunRefillCost;
            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

        }
        else if (player.currentCurrency < shotgunRefillCost && shotgunBought == true && shotgunScript.currentAmmoCapacity < shotgunScript.maxAmmoCapacity)
        {
            pistolScript.currentAmmoCapacity += shotgunAffordableRefill;
            player.currentCurrency -= shotgunAffordableRefillCost;
            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

            if (shotgunScript.currentAmmoCapacity >= shotgunScript.maxAmmoCapacity)
            {
                shotgunScript.currentAmmoCapacity = shotgunScript.maxAmmoCapacity;
            }
            else if (shotgunScript.currentAmmoCapacity <= shotgunScript.minAmmoCapacity)
            {
                shotgunScript.currentAmmoCapacity = shotgunScript.minAmmoCapacity;
            }
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "PistolStation")
            {
                pistolStationButton.gameObject.SetActive(true);
            }
            else if (gameObject.name == "ShotgunStation")
            {
                shotgunStationButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.name == "PistolStation")
            {
                pistolStationButton.gameObject.SetActive(false);
            }
            else if(gameObject.name == "ShotgunStation")
            {
                shotgunStationButton.gameObject.SetActive(false);
            }

        }
        
    }

}
