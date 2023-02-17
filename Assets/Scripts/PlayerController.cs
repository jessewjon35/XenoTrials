using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject player;
    public GameObject enemy;

    private float screenWidth;
    private float movementSpeed = 10;
    private float jumpForce = 14;
    private float jumpStaminaUsage = 15;

    
    public PlayerUI playerUi;
    
    public Player playerScript;    
    public GravitySwap gravitySwap;
    

    public bool isJumping;
    public bool isTouching;



    private void Awake()
    {
        //Input.multiTouchEnabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        screenWidth = Screen.width;
        rb = player.GetComponent<Rigidbody2D>();

        isJumping = false;
        isTouching = false;


        
        
       


    }
    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        PlayerMovement();
        
        
        
    }

    // Update is called once per frame
    public void PlayerMovement()
    {
        int i = 0;


        //loop over every touch found
        while (i < Input.touchCount)
        {


            if (Input.GetTouch(i).position.x > screenWidth / 3 * 2 && gravitySwap.isUpsideDown == false)
            {
                //move right on ground
                MovePlayer(1.0f);
                isTouching = true;
                
            }

            else if (Input.GetTouch(i).position.x < screenWidth / 3 && gravitySwap.isUpsideDown == false)
            {
                //move left on ground
                MovePlayer(-1.0f);
                isTouching = true;

            }

            else if (Input.GetTouch(i).position.x > screenWidth / 3 * 2 && gravitySwap.isUpsideDown == true)
            {
                //move right on ceiling
                MovePlayer(-1.0f);
                isTouching = true;

            }

            else if (Input.GetTouch(i).position.x < screenWidth / 3 && gravitySwap.isUpsideDown == true)
            {
                //move left on ceiling
                MovePlayer(1.0f);
                isTouching = true;

            }

            
            i++;
        }

    }

    private void MovePlayer(float horizontalMovement)
    {
        rb.transform.Translate(new Vector2(horizontalMovement * movementSpeed * Time.deltaTime, 0));
    }

    public void Jump()
    {


        if (isJumping == false && gravitySwap.isUpsideDown == false && playerScript.currentStamina >= jumpStaminaUsage)
        {
            
            
            rb.velocity = new Vector2(0, jumpForce);

            playerScript.currentStamina -= jumpStaminaUsage;
            playerUi.SetStamina();
           
            StartCoroutine(JumpLimit());
           
            StartCoroutine(WaitBeforeJump());

            
        }
        else if (isJumping == false && gravitySwap.isUpsideDown == true && playerScript.currentStamina >= jumpStaminaUsage)
        {
            
            rb.velocity = new Vector2(0, -jumpForce);
            playerScript.currentStamina -= jumpStaminaUsage;
            playerUi.SetStamina();

            StartCoroutine(JumpLimit());
            
            StartCoroutine(WaitBeforeJump());
            
        }
        
        
    }  

    IEnumerator JumpLimit()
    {
        
        yield return new WaitForSeconds(.3f);
        isJumping = true;
        
    }

    IEnumerator WaitBeforeJump()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }

       

   
}
