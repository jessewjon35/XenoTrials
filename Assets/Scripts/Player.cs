using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Enemy enemy;

    public PlayerUI playerUi;
    public GravitySwap gravitySwap;
    public PlayerController playerController;

    public Rigidbody2D rb;
    private BoxCollider2D playerCollider;

    public float maxHealth = 100f;
    public float minHealth = 0f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float minStamina = 0f;
    public float currentStamina;

    public int currentCurrency;
    private int minCurrency = 0;

    public int currentSealer;
    private int minSealer = 0;

    public Slider healthSlider;
    public Slider StaminaSlider;

    public GameObject gameOverPanel;

    public bool isInvincible;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerCollider = GetComponent<BoxCollider2D>();

        playerUi.SetMaxHealth();
        playerUi.SetMaxStamina();

        GetComponent<BoxCollider2D>();

        playerUi.ResetCurrency();

        gameOverPanel.SetActive(false);

        isInvincible = false;

        Time.timeScale = 1f;
        

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

        if(currentSealer <= minSealer)
        {
            currentSealer = minSealer;
        }
        

        if(gravitySwap.isGroundedAfterGravity == true)
        {
            gravitySwap.gravityPoundCount = 0;
        }

        if(gravitySwap.isGroundedAfterGravity == false && gravitySwap.currentGravityCharge > 0)
        {
            isInvincible = true;
        }

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

        if (collision.collider == playerCollider && collision.gameObject.tag == "Enemy")
        {
            
            if (gravitySwap.currentGravityCharge == 0 || playerController.isGroundedAfterJumping == false || gravitySwap.isGroundedAfterGravity == true)
            {
                isInvincible = false;

                currentHealth -= enemy.enemyCollisionDamage;
                playerUi.SetHealth();

                Debug.Log(currentHealth);
            }

            else if(gravitySwap.currentGravityCharge > 0 && gravitySwap.currentGravityCharge <= 25 && gravitySwap.isGroundedAfterGravity == false)
            {
                
                isInvincible = true;
                gravitySwap.gravityPoundCount++;
                if (gravitySwap.gravityPoundCount < 2)
                {
                    
                    currentCurrency += gravitySwap.gravityPoundCurrency;
                    playerUi.SetCurrency();
                }

                else if (gravitySwap.gravityPoundCount >= 2)
                {
                    isInvincible = false;

                    currentHealth -= enemy.enemyCollisionDamage;
                    playerUi.SetHealth();

                    Debug.Log(currentHealth);
                }
                
            }

            else if (gravitySwap.currentGravityCharge >= 26 && gravitySwap.currentGravityCharge <= 50 && playerController.isGroundedAfterJumping == true && gravitySwap.isGroundedAfterGravity == false)
            {
                gravitySwap.gravityPoundCount++;

                if (gravitySwap.gravityPoundCount < 3)
                {
                    isInvincible = true;
                    currentCurrency += gravitySwap.gravityPoundCurrency;
                    playerUi.SetCurrency();
                }

                else if (gravitySwap.gravityPoundCount >= 3)
                {
                    isInvincible = false;

                    currentHealth -= enemy.enemyCollisionDamage;
                    playerUi.SetHealth();

                    Debug.Log(currentHealth);
                }
            }

            else if (gravitySwap.currentGravityCharge >= 51 && gravitySwap.currentGravityCharge <= 75 && playerController.isGroundedAfterJumping == true && gravitySwap.isGroundedAfterGravity == false)
            {
                gravitySwap.gravityPoundCount++;

                if (gravitySwap.gravityPoundCount < 4)
                {
                    isInvincible = true;
                    currentCurrency += gravitySwap.gravityPoundCurrency;
                    playerUi.SetCurrency();
                }
                else if (gravitySwap.gravityPoundCount >= 4)
                {
                    isInvincible = false;

                    currentHealth -= enemy.enemyCollisionDamage;
                    playerUi.SetHealth();
                    
                    Debug.Log(currentHealth);
                }
            }

            else if (gravitySwap.currentGravityCharge >= 76 && gravitySwap.currentGravityCharge <= 100 && playerController.isGroundedAfterJumping == true && gravitySwap.isGroundedAfterGravity == false)
            {
                gravitySwap.gravityPoundCount++;

                if (gravitySwap.gravityPoundCount < 5)
                {
                    isInvincible = true;
                    currentCurrency += gravitySwap.gravityPoundCurrency;
                    playerUi.SetCurrency();
                }
                else if (gravitySwap.gravityPoundCount >= 5)
                {
                    isInvincible = false;

                    currentHealth -= enemy.enemyCollisionDamage;
                    playerUi.SetHealth();
                   
                    Debug.Log(currentHealth);
                }
            }

            //isInvincible = false;

        }

        if(collision.gameObject.tag == "floor" && collision.gameObject.tag == "Door" && playerController.isGroundedAfterJumping == false)
        {
            playerController.isGroundedAfterJumping = true;
        }
        else if(collision.gameObject.tag == "floor" && gravitySwap.isGroundedAfterGravity == false)
        {
            gravitySwap.isGroundedAfterGravity = true;
            isInvincible = false;
            Time.timeScale = 1f;
            gravitySwap.currentGravityCharge = gravitySwap.minGravityCharge;
            playerUi.SetGravityCharge();
        }
    }


}
    







