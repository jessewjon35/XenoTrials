using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 playerDir;

    public GameObject player;
    public GameObject enemy;
    public GameObject starterMelee;
    public ParticleSystem movementParticles;
    public ParticleSystem jumpingParticles;
    public ParticleSystem landingParticles;

    //public Joystick joystick;

    private float screenWidth;
    public float movementSpeed = 10f;
    private float jumpForce = 15;
    private float jumpStaminaUsage = 15;

    
    public PlayerUI playerUi;
    
    public Player playerScript;    
    public GravitySwap gravitySwap;
    

    //public bool isJumping;
    public bool isTouching;
    public bool isFacingRight;
    public bool isMovingRight;
    public bool isGroundedAfterJumping;
    



    private void Awake()
    {
        Input.multiTouchEnabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {

        screenWidth = Screen.width;
        rb = player.GetComponent<Rigidbody2D>();

        //isJumping = false;
        isTouching = false;
        isFacingRight = true;
        isGroundedAfterJumping = true;

        //bulletSpawn.transform.Rotate(0f, 0f, 0f);

        



    }
    public void FixedUpdate()
    {
        

        if(isMovingRight == false && isFacingRight && gravitySwap.isUpsideDown == false)
        {
            FlipPlayer();
        }
        else if(isMovingRight ==true && !isFacingRight && gravitySwap.isUpsideDown == false)
        {
            FlipPlayer();
        }

        else if (isMovingRight == false && isFacingRight && gravitySwap.isUpsideDown == true)
        {
            
            FlipPlayer();
        }
        else if (isMovingRight == true && !isFacingRight && gravitySwap.isUpsideDown == true)
        {
            
            FlipPlayer();
        }

        PlayerMovement();

    }

    private void Update()
    {

        if (gravitySwap.isGroundedAfterGravity == false && isGroundedAfterJumping == false)
        {
            movementParticles.Stop();
        }
        
        
        
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
                isMovingRight = true;
                
            }

             else if (Input.GetTouch(i).position.x < screenWidth / 3 && gravitySwap.isUpsideDown == false)
             {
                
                 //move left on ground
                 MovePlayer(-1.0f);
                 isTouching = true;
                isMovingRight = false;
                
            }

             else if (Input.GetTouch(i).position.x > screenWidth / 3 * 2 && gravitySwap.isUpsideDown == true)
             {
                //move right on ceiling
                
                MovePlayer(1.0f);
                 isTouching = true;
                isMovingRight = true;
                

            }

             else if (Input.GetTouch(i).position.x < screenWidth / 3 && gravitySwap.isUpsideDown == true)
             {
                //move left on ceiling
                
                 MovePlayer(-1.0f);
                 isTouching = true;
                isMovingRight = false;
                

            }
            
            //isTouching = false;

             i++;

            if(i >= 2 && gravitySwap.isGroundedAfterGravity == true)
            {
                gravitySwap.GravityCharge();
            }

         }

        /*if (joystick.Horizontal > 0f && gravitySwap.isUpsideDown == false)
        {
            //FlipPlayer();
            //move right on ground
            MovePlayer(1.0f);
            

            isFacingRight = true;
            

        }
        else if (joystick.Horizontal < 0f && gravitySwap.isUpsideDown == false)
        {
            
            //move left on ground
            MovePlayer(-1.0f);
            //FlipPlayer();
            


            isFacingRight = false;
        }        
        else if (joystick.Horizontal > 0f && gravitySwap.isUpsideDown == true)
        {
            //FlipPlayer();
            //move right on ceiling
            MovePlayer(1.0f);
            

            isFacingRight = true;
        }
        else if(joystick.Horizontal < 0f && gravitySwap.isUpsideDown == true)
        {
            //move left on ceiling
            MovePlayer(-1.0f);
            //FlipPlayer();


            isFacingRight = false;
        }*/


    }

    

    private void MovePlayer(float horizontalMovement)
    {
        rb.transform.Translate(new Vector2(horizontalMovement * movementSpeed * Time.deltaTime, 0));

        movementParticles.Play();
    }

    public void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        starterMelee.transform.Rotate(0f, 180f, 0f);

        movementParticles.transform.Rotate(0f, 180f, 0f);

        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        gameObject.transform.localScale = theScale;

        

    }

    public void Jump()
    {


        if (isGroundedAfterJumping == true && gravitySwap.isUpsideDown == false && playerScript.currentStamina >= jumpStaminaUsage)
        {
            
            
            rb.velocity = new Vector2(0, jumpForce);

            jumpingParticles.Play();

            playerScript.currentStamina -= jumpStaminaUsage;
            playerUi.SetStamina();
           
            StartCoroutine(JumpLimit());
           
            StartCoroutine(WaitBeforeJump());

            
        }
        else if (isGroundedAfterJumping == true && gravitySwap.isUpsideDown == true && playerScript.currentStamina >= jumpStaminaUsage)
        {
           
            rb.velocity = new Vector2(0, -jumpForce);

            jumpingParticles.Play();

            playerScript.currentStamina -= jumpStaminaUsage;
            playerUi.SetStamina();

            StartCoroutine(JumpLimit());
            
            StartCoroutine(WaitBeforeJump());
            
        }
        
        
    }  

    IEnumerator JumpLimit()
    {
        
        yield return new WaitForSeconds(.3f);
        isGroundedAfterJumping = false;
        
    }

    IEnumerator WaitBeforeJump()
    {
        
        yield return new WaitForSeconds(1f);
        isGroundedAfterJumping = true;

    }

    




}
