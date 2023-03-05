using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private Player player;
    

    Vector3 shake;
    private bool isGrounded;
    public bool isUpsideDown;

    //private float shakeWaitTime = .7f;
    //private float minWaitTime = 0f;
    private float gravityStamina = 15f;

    

    // Start is called before the first frame update
    void Start()
    {

        isGrounded = true;        
        isUpsideDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void FixedUpdate()
    {
        ShakeDetection();

        //TimeBetweenShakes();
    }



    public void ShakeDetection()
    {
        //new acceleration Input from mobile device
        shake = Input.acceleration;

        if (shake.sqrMagnitude >= 1.5f && isGrounded == true)
        {

            

            GravityChange();

            


        }

    }

    public void GravityChange()
    {
        //ground gravity = 1
        //multiplied by -1 = -1 which is ceiling gravity
        //vice versa

        if (isUpsideDown == false && isGrounded == true && player.currentStamina >= gravityStamina)
        {
            rb.gravityScale *= -1;

            player.currentStamina -= gravityStamina;

            //player flip from bottom to top
            Vector3 playerRotation = new Vector3(0, 180f, 180f);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            //Time.timeScale = .5f;

            isUpsideDown = true;
            isGrounded = false;

        }
        else if(isUpsideDown == true && isGrounded == true && player.currentStamina >= gravityStamina)
        {
            rb.gravityScale *= -1;

            player.currentStamina -= gravityStamina;

            //player flip top to bottom
            Vector3 playerRotation = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            //Time.timeScale = .5f;

            isUpsideDown = false;
            isGrounded = false;

        }
        

        /*if (rb.transform.position.y <= -3.7 && gravityChanged == false && isMoving == false)
        {
            rb.gravityScale *= -1;
            isUpsideDown = true;

            //player flip from bottom to top
            Vector3 playerRotation = new Vector3(0, 0, -180);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            isMoving = true;
            gravityChanged = false;
            

        }
        else if (rb.transform.position.y >= 4 && gravityChanged == false && isMoving == false)
        {
            rb.gravityScale *= -1;
            isUpsideDown = false;

            //player flip from top to bottom
            Vector3 playerRotation = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            isMoving = true;
            gravityChanged = false;

        }*/
    }   
    

    /*public void TimeBetweenShakes()
    {
        if (isGrounded == false)
        {
            minWaitTime += Time.deltaTime;
            Debug.Log(minWaitTime + Time.deltaTime);

            Time.timeScale = .5f;
        }

        if (minWaitTime >= shakeWaitTime)
        {
            ResetTimer();
            isGrounded = true;

            Time.timeScale = 1f;
        }



    }

    public void ResetTimer()
    {
        minWaitTime = 0f;
        
        Debug.Log("Timer Reset");
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
            Time.timeScale = 1f;

        }
    }


}
