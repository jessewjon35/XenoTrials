using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public float maxHealth = 100f;
    public float minHealth = 0f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float minStamina = 0f;
    public float currentStamina;

    public float currentCurrency;
    public float minCurrency = 0f;

    public Slider healthSlider;
    public Slider StaminaSlider;

    [HideInInspector]
    public Enemy enemy;
    
    public PlayerUI playerUi;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerUi.SetMaxHealth();
        playerUi.SetMaxStamina();

        GetComponent<BoxCollider2D>();

        currentCurrency = minCurrency;

    }

    private void FixedUpdate()
    {
        
      
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(currentHealth <= minHealth)
        {
            currentHealth = minHealth;
        }

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        } 
        


        if (currentStamina <= minStamina)
        {
            currentStamina = minStamina;
        }

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }

        if(currentStamina < maxStamina)
        {
            StaminaRecharge();
        }


        if(currentCurrency <= minCurrency)
        {
            currentCurrency = minCurrency;
        }
        

        //Debug.Log(currentStamina);
        //Debug.Log(Input.acceleration);

    }

    public void StaminaRecharge()
    {
        currentStamina += 10 * Time.deltaTime;
        playerUi.SetStamina();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            
            currentHealth -= enemy.enemyCollisionDamage;
            playerUi.SetHealth();

            Debug.Log(currentHealth);
            
        }
        
        
    }


}
    







