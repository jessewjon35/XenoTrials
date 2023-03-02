using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    
    public Player player;
    public Pistol pistol;
    public Shotgun shotgun;

    public Slider healthSlider;
    public Slider staminaSlider;

    public TMP_Text currencyText;
    public TMP_Text pistolAmmoText;
    public TMP_Text shotgunAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = player.currentHealth;
        staminaSlider.value = player.currentStamina;

        currencyText.text = "$ " + player.currentCurrency.ToString();

       
        SetCurrency();

        pistolAmmoText.enabled = false;
        shotgunAmmoText.enabled = false;
        ResetAmmo();
        SetPistolAmmo();
        SetShotgunAmmo();

       

    }

    // Update is called once per frame
    void Update()
    {

        SetCurrency();
        

    }

    public void SetMaxHealth()
    {
        healthSlider.maxValue = player.maxHealth;
        
    }

    public void SetHealth()
    {
        healthSlider.value = player.currentHealth;
    }

    public void SetMaxStamina()
    {
        staminaSlider.maxValue = player.maxStamina;
       
    }

    public void SetStamina()
    {
        staminaSlider.value = player.currentStamina;
    }

    public void SetCurrency()
    {
        currencyText.text = "$ " + player.currentCurrency.ToString();
    }


    public void SetPistolAmmo()
    {     
        pistolAmmoText.text = "Ammo: " + pistol.currentAmmoClip.ToString() + " / " + pistol.currentAmmoCapacity.ToString();
        PlayerPrefs.SetFloat("PistolAmmoClip", pistol.currentAmmoClip);
        PlayerPrefs.SetFloat("PistolAmmoCapacity", pistol.currentAmmoCapacity);
    }

    public void SetShotgunAmmo()
    {
        shotgunAmmoText.text = "Ammo: " + shotgun.currentAmmoClip.ToString() + " / " + shotgun.currentAmmoCapacity.ToString();
        PlayerPrefs.SetFloat("ShotgunAmmoClip", shotgun.currentAmmoClip);
        PlayerPrefs.SetFloat("ShotgunAmmoCapacity", shotgun.currentAmmoCapacity);
    }

    public void ResetAmmo()
    {
        PlayerPrefs.DeleteKey("PistolAmmoClip");
        PlayerPrefs.DeleteKey("PistolAmmoCapacity");

        PlayerPrefs.DeleteKey("ShotgunAmmoClip");
        PlayerPrefs.DeleteKey("ShotgunAmmoCapacity");
    }

}
