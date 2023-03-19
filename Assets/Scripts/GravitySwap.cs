using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private Player player;
    public PlayerUI playerUi;
    public PlayerController playerController;
    

    Vector3 shake;
    public bool isGroundedAfterGravity;
    public bool isUpsideDown;

    //private float shakeWaitTime = .7f;
    //private float minWaitTime = 0f;
    //private float gravityStamina = 10f;
    public float currentGravityCharge;
    public float maxGravityCharge = 100f;
    public float minGravityCharge = 0f;
    public int gravityPoundCount;
    public int gravityPoundCurrency = 30;

    public ParticleSystem landingParticles;
    

    // Start is called before the first frame update
    void Start()
    {

        isGroundedAfterGravity = true;        
        isUpsideDown = false;

        currentGravityCharge = minGravityCharge;

    }

    // Update is called once per frame
    void Update()
    {

        if(currentGravityCharge >= maxGravityCharge)
        {
            currentGravityCharge = maxGravityCharge;
        }
        else if(currentGravityCharge <= minGravityCharge)
        {
            currentGravityCharge = minGravityCharge;
        }
        

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

        if (shake.sqrMagnitude >= 2f && isGroundedAfterGravity == true && currentGravityCharge <= player.currentStamina)
        {
            
            GravityChange();          

        }
        
        
    }

    public void GravityCharge()
    {
        currentGravityCharge += 10f * Time.deltaTime;
        Debug.Log(currentGravityCharge);
        playerUi.SetGravityCharge();
        
        
    }

    public void GravityChange()
    {
        //ground gravity = 1
        //multiplied by -1 = -1 which is ceiling gravity
        //vice versa

        if (isUpsideDown == false && isGroundedAfterGravity == true && player.currentStamina >= currentGravityCharge)
        {
            rb.gravityScale *= -1;

            //Time.timeScale = .6f;

            player.currentStamina -= currentGravityCharge;

            //player flip from bottom to top
            Vector3 playerRotation = new Vector3(0, 180f, 180f);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            

            isUpsideDown = true;
            isGroundedAfterGravity = false;

            

        }
        else if(isUpsideDown == true && isGroundedAfterGravity == true && player.currentStamina >= currentGravityCharge)
        {
            rb.gravityScale *= -1;

            //Time.timeScale = .6f;

            player.currentStamina -= currentGravityCharge;

            //player flip top to bottom
            Vector3 playerRotation = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            

            isUpsideDown = false;
            isGroundedAfterGravity = false;

            

        }

        
        

        
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

    


}
