using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    public Player player;
    public Enemy enemy;
    public GravitySwap gravitySwap;
    public Timer timer;

    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider gravityChargeSlider;

    public TMP_Text currencyText;  
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text sealerText;
    
    

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = player.currentHealth;
        staminaSlider.value = player.currentStamina;

        currencyText.text = "$ " + player.currentCurrency.ToString();
        healthText.text = player.currentHealth.ToString();
        staminaText.text = player.currentStamina.ToString();
        sealerText.text = "Sealer: " + player.currentSealer.ToString();
        
        
    }

    // Update is called once per frame
    void Update()
    {




    }

    public void SetMaxHealth()
    {
        healthSlider.maxValue = player.maxHealth;

    }

    public void SetHealth()
    {
        healthSlider.value = player.currentHealth;
        healthText.text = player.currentHealth.ToString();
    }

    public void SetMaxStamina()
    {
        staminaSlider.maxValue = player.maxStamina;

    }

    public void SetStamina()
    {
        staminaSlider.value = player.currentStamina;
        staminaText.text = player.currentStamina.ToString();
    }

    public void SetCurrency()
    {
        currencyText.text = "$ " + player.currentCurrency.ToString();
        PlayerPrefs.SetInt("Currency", player.currentCurrency);

    }

    public void ResetCurrency()
    {
        PlayerPrefs.DeleteKey("Currency");
    }


    /*public void SetPistolAmmo()
    {
        pistolAmmoText.text = "Ammo: " + pistol.currentAmmoClip.ToString() + " / " + pistol.currentAmmoCapacity.ToString();
        PlayerPrefs.SetFloat("PistolAmmoClip", pistol.currentAmmoClip);
        PlayerPrefs.SetFloat("PistolAmmoCapacity", pistol.currentAmmoCapacity);
        PlayerPrefs.Save();
    }

    public void SetShotgunAmmo()
    {
        shotgunAmmoText.text = "Ammo: " + shotgun.currentAmmoClip.ToString() + " / " + shotgun.currentAmmoCapacity.ToString();
        PlayerPrefs.SetFloat("ShotgunAmmoClip", shotgun.currentAmmoClip);
        PlayerPrefs.SetFloat("ShotgunAmmoCapacity", shotgun.currentAmmoCapacity);
        PlayerPrefs.Save();
    }

    public void ResetAmmo()
    {
        PlayerPrefs.DeleteKey("PistolAmmoClip");
        PlayerPrefs.DeleteKey("PistolAmmoCapacity");

        PlayerPrefs.DeleteKey("ShotgunAmmoClip");
        PlayerPrefs.DeleteKey("ShotgunAmmoCapacity");
    }*/

    public void SetGravityCharge()
    {
        gravityChargeSlider.value = gravitySwap.currentGravityCharge;
    }

    public void SetSealer()
    {
        sealerText.text = "Sealer: " + player.currentSealer.ToString();
        PlayerPrefs.SetInt("Sealer", player.currentSealer);

    }

    public void ResetSealer()
    {
        PlayerPrefs.DeleteKey("Sealer");
    }

    public void SetTimer()
    {
        timer.timerText.text = timer.Hours.ToString("00") + ":" + timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
        PlayerPrefs.SetFloat("Timer", timer.currentTime);
    }

}
