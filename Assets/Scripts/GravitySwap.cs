using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerController playerController;
    

    Vector3 shake;
    private bool isMoving;
    public bool isUpsideDown;

    private float shakeWaitTime = .7f;
    private float minWaitTime = 0f;

    

    // Start is called before the first frame update
    void Start()
    {

        isMoving = false;        
        isUpsideDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeDetection();

        TimeBetweenShakes();
    }

    

    public void ShakeDetection()
    {
        //new acceleration Input from mobile device
        shake = Input.acceleration;

        if (shake.sqrMagnitude >= 1.5f && isMoving == false)
        {

            

            GravityChange();

            


        }

    }

    public void GravityChange()
    {
        //ground gravity = 1
        //multiplied by -1 = -1 which is ceiling gravity
        //vice versa

        if(isUpsideDown == false && isMoving == false)
        {
            rb.gravityScale *= -1;

            

            //player flip from bottom to top
            Vector3 playerRotation = new Vector3(0, 180f, 180f);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            

            isUpsideDown = true;
            isMoving = true;

        }
        else if(isUpsideDown == true && isMoving == false)
        {
            rb.gravityScale *= -1;

            

            //player flip top to bottom
            Vector3 playerRotation = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(playerRotation);
            rb.transform.rotation = rotation;

            

            isUpsideDown = false;
            isMoving = true;

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
    

    public void TimeBetweenShakes()
    {
        if (isMoving == true)
        {
            minWaitTime += Time.deltaTime;
            Debug.Log(minWaitTime + Time.deltaTime);
        }

        if (minWaitTime >= shakeWaitTime)
        {
            ResetTimer();
            isMoving = false;

        }



    }

    public void ResetTimer()
    {
        minWaitTime = 0f;
        
        Debug.Log("Timer Reset");
    }

   
}
