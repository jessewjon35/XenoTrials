using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    public Player player;

    public Slider healthSlider;
    public Slider staminaSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = player.currentHealth;
        staminaSlider.value = player.currentStamina;
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

}
