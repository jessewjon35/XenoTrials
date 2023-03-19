using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Player player;
    public PlayerController playerController;
    public Pistol pistolScript;
    public Shotgun shotgunScript;
    public PlayerUI playerUi;
    public WeaponSwitch weaponSwitch;

    public Button shopButton;

    public Button pistolButton;
    public Button shotgunButton;
    public Button navRepairButton;
    public Button commRepairButton;

    public Button shootButton;

    public GameObject shopPanel;
    public GameObject pistol;
    public GameObject shotgun;

    public TMP_Text pistolBoughtText;
    public TMP_Text shotgunBoughtText;

    public TMP_Text navRepairPlaceholderText;
    public TMP_Text commRepairPlaceholderText;

    public TMP_Text navRepairPartsText;
    public TMP_Text commRepairPartsText;

    public int pistolGunCost;
    public int pistolAmmoCost;

    public int shotgunGunCost;
    public int shotgunAmmoCost;

    // Start is called before the first frame update
    void Start()
    {

        shopPanel.SetActive(false);

        weaponSwitch.pistolBought = false;
        weaponSwitch.shotgunBought = false;

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

    public void PistolPurchase()
    {
        if (player.currentCurrency >= pistolGunCost && weaponSwitch.pistolBought == false)
        {
            shootButton.gameObject.SetActive(true);

            pistol.SetActive(true);
            shotgun.SetActive(false);
            weaponSwitch.pistolBought = true;

            playerUi.pistolAmmoText.enabled = true;
            playerUi.shotgunAmmoText.enabled = false;
            player.currentCurrency -= pistolGunCost;

            playerUi.SetCurrency();
            playerUi.SetPistolAmmo();

            weaponSwitch.SwapEnabledCheck();
        }
    }

    public void ShotgunPurchase()
    {
        if (player.currentCurrency >= shotgunGunCost && weaponSwitch.shotgunBought == false)
        {
            shootButton.gameObject.SetActive(true);

            shotgun.SetActive(true);
            pistol.SetActive(false);
            weaponSwitch.shotgunBought = true;
            playerUi.shotgunAmmoText.enabled = true;
            playerUi.pistolAmmoText.enabled = false;
            player.currentCurrency -= shotgunGunCost;

            playerUi.SetCurrency();
            playerUi.SetShotgunAmmo();

            weaponSwitch.SwapEnabledCheck();

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
        shopButton.gameObject.SetActive(false);
    }

}
