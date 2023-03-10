using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Enemy enemy;

    public PlayerUI playerUi;

    public Rigidbody2D rb;

    public float maxHealth = 100f;
    public float minHealth = 0f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float minStamina = 0f;
    public float currentStamina;

    public int currentCurrency;
    private int minCurrency = 0;

    public Slider healthSlider;
    public Slider StaminaSlider;

    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerUi.SetMaxHealth();
        playerUi.SetMaxStamina();

        GetComponent<BoxCollider2D>();

        playerUi.ResetCurrency();

        gameOverPanel.SetActive(false);
        

    }

    

    // Update is called once per frame
    void Update()
    {
        playerUi.SetCurrency();

        if(currentHealth <= minHealth)
        {
            currentHealth = minHealth;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            
            currentHealth -= enemy.enemyCollisionDamage;
            playerUi.SetHealth();

            Debug.Log(currentHealth);
            
        }
        
        
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            currentHealth -= enemy.enemyCollisionDamage;
            playerUi.SetHealth();

            Debug.Log(currentHealth);

        }
    }


}
    







