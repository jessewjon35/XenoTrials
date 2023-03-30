using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunStations : MonoBehaviour
{
    /*public Player player;
    public Pistol pistolScript;
    public Shotgun shotgunScript;
    public PlayerUI playerUi;
    public WeaponSwitch weaponSwitch;

    public Button pistolStationButton;
    public Button shotgunStationButton;
    public Button pistolAmmoPurchaseButton;
    public Button shotgunAmmoPurchaseButton;
    public Button shootButton;

    public GameObject pistol;
    public GameObject shotgun;

    public int gunCost;
    public int ammoCost;

    private int pistolRefillCost;
    private int pistolRefillCount;
    private int pistolAffordableRefill;
    private int pistolAffordableRefillCost;

    private int shotgunRefillCost;
    private int shotgunRefillCount;
    private int shotgunAffordableRefill;
    private int shotgunAffordableRefillCost;




    private void Awake()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
        shootButton.gameObject.SetActive(false);

        pistol.SetActive(false);
        shotgun.SetActive(false);

        pistolStationButton.gameObject.SetActive(false);
        shotgunStationButton.gameObject.SetActive(false);

        pistolAmmoPurchaseButton.gameObject.SetActive(false);
        shotgunAmmoPurchaseButton.gameObject.SetActive(false);

        weaponSwitch.pistolBought = false;
        weaponSwitch.shotgunBought = false;

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
        if (player.currentCurrency >= gunCost && weaponSwitch.pistolBought == false)
        {
            shootButton.gameObject.SetActive(true);

            pistol.SetActive(true);
            shotgun.SetActive(false);
            weaponSwitch.pistolBought = true;

            playerUi.pistolAmmoText.enabled = true;
            playerUi.shotgunAmmoText.enabled = false;
            player.currentCurrency -= gunCost;

            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();

            weaponSwitch.SwapEnabledCheck();
        }





    }

    public void ShotgunPurchase()
    {
        if (player.currentCurrency >= gunCost && weaponSwitch.shotgunBought == false)
        {
            shootButton.gameObject.SetActive(true);

            shotgun.SetActive(true);
            pistol.SetActive(false);
            weaponSwitch.shotgunBought = true;
            playerUi.shotgunAmmoText.enabled = true;
            playerUi.pistolAmmoText.enabled = false;
            player.currentCurrency -= gunCost;

            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

            weaponSwitch.SwapEnabledCheck();

        }

    }

    public void PistolAmmoPurchase()
    {
        if (player.currentCurrency >= pistolRefillCost && weaponSwitch.pistolBought == true && pistolScript.currentAmmoCapacity < pistolScript.maxAmmoCapacity)
        {
            pistol.SetActive(true);
            shotgun.SetActive(false);

            pistolScript.currentAmmoCapacity = pistolScript.maxAmmoCapacity;
            pistolScript.currentAmmoClip = pistolScript.maxAmmoClip;
            player.currentCurrency -= pistolRefillCost;

            playerUi.shotgunAmmoText.enabled = false ;
            playerUi.pistolAmmoText.enabled = true;


            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();

        }

        if (player.currentCurrency < pistolRefillCost && weaponSwitch.pistolBought == true && pistolScript.currentAmmoCapacity < pistolScript.maxAmmoCapacity)
        {
            pistol.SetActive(true);
            shotgun.SetActive(false);

            pistolScript.currentAmmoCapacity += pistolAffordableRefill;
            player.currentCurrency -= pistolAffordableRefillCost;

            playerUi.shotgunAmmoText.enabled = false;
            playerUi.pistolAmmoText.enabled = true;

            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();


        }
    }

    public void ShotgunAmmoPurchase()
    {
        if (player.currentCurrency >= shotgunRefillCost && weaponSwitch.shotgunBought == true && shotgunScript.currentAmmoCapacity < shotgunScript.maxAmmoCapacity)
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);

            shotgunScript.currentAmmoCapacity = shotgunScript.maxAmmoCapacity;
            shotgunScript.currentAmmoClip = shotgunScript.maxAmmoClip;
            player.currentCurrency -= shotgunRefillCost;

            playerUi.shotgunAmmoText.enabled = true;
            playerUi.pistolAmmoText.enabled = false;

            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

        }
        else if (player.currentCurrency < shotgunRefillCost && weaponSwitch.shotgunBought == true && shotgunScript.currentAmmoCapacity < shotgunScript.maxAmmoCapacity)
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);

            shotgunScript.currentAmmoCapacity += shotgunAffordableRefill;
            player.currentCurrency -= shotgunAffordableRefillCost;

            playerUi.shotgunAmmoText.enabled = true;
            playerUi.pistolAmmoText.enabled = false;

            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            if(weaponSwitch.pistolBought == false && gameObject.tag == "pistolstation")
        {
            pistolStationButton.gameObject.SetActive(true);
        }
        else if(weaponSwitch.pistolBought == true && gameObject.tag == "pistolstation")
        {
            pistolAmmoPurchaseButton.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Player")
            if(weaponSwitch.shotgunBought == false && gameObject.name == "ShotgunStation" || gameObject.name == "ShotgunStation (1)")
        {
            shotgunStationButton.gameObject.SetActive(true);
        }
        else if(weaponSwitch.shotgunBought == true && gameObject.name == "ShotgunStation" || gameObject.name == "ShotgunStation (1)")
        {
            shotgunAmmoPurchaseButton.gameObject.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pistolStationButton.gameObject.SetActive(false);
        pistolAmmoPurchaseButton.gameObject.SetActive(false);

        shotgunStationButton.gameObject.SetActive(false);
        shotgunAmmoPurchaseButton.gameObject.SetActive(false);
    }*/


}


