using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    
    public Player player;

    public Slider healthSlider;
    public Slider staminaSlider;

    public TMP_Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = player.currentHealth;
        staminaSlider.value = player.currentStamina;

        ResetCurrency();
        currencyText.text = "$ " + player.currentCurrency;
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
        PlayerPrefs.SetFloat("Currency", player.currentCurrency);
    }

    public void ResetCurrency()
    {
        PlayerPrefs.DeleteKey("Currency");
    }

}
