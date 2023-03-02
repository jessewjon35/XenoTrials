using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 playerDir;

    public GameObject player;
    public GameObject enemy;
    public GameObject bulletSpawn;
    public GameObject pelletSpawn1;
    public GameObject pelletSpawn2;
    public GameObject pelletSpawn3;

    public Joystick joystick;

    private float screenWidth;
    private float movementSpeed = 7.5f;
    private float jumpForce = 14;
    private float jumpStaminaUsage = 15;

    
    public PlayerUI playerUi;
    
    public Player playerScript;    
    public GravitySwap gravitySwap;
    

    public bool isJumping;
    public bool isTouching;
    public bool isFacingRight;
    



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

        isFacingRight = true;

        //bulletSpawn.transform.Rotate(0f, 0f, 0f);





    }
    public void FixedUpdate()
    {
        

        if(isFacingRight == false && joystick.Horizontal > 0f && gravitySwap.isUpsideDown == false)
        {
            FlipPlayer();
        }
        else if(isFacingRight == true && joystick.Horizontal < 0f && gravitySwap.isUpsideDown == false)
        {
            FlipPlayer();
        }

        if (isFacingRight == false && joystick.Horizontal > 0f && gravitySwap.isUpsideDown == true)
        {
            
            FlipPlayer();
        }
        else if (isFacingRight == true && joystick.Horizontal < 0f && gravitySwap.isUpsideDown == true)
        {
            
            FlipPlayer();
        }

        PlayerMovement();

    }

    private void Update()
    {
        
        
        
        
    }

    // Update is called once per frame
    public void PlayerMovement()
    {
        /* int i = 0;


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
         }*/

        if (joystick.Horizontal > 0f && gravitySwap.isUpsideDown == false)
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
        }


    }

    private void MovePlayer(float horizontalMovement)
    {
        rb.transform.Translate(new Vector2(horizontalMovement * movementSpeed * Time.deltaTime, 0));

        
    }

    public void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        bulletSpawn.transform.Rotate(0f, 180f, 0f);
        pelletSpawn1.transform.Rotate(0f, 180f, 0f);
        pelletSpawn2.transform.Rotate(0f, 180f, 0f);
        pelletSpawn3.transform.Rotate(0f, 180f, 0f);

    Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        
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
