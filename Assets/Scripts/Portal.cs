using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject primaryPortal;
    public GameObject secondaryPortal;

    private float cooldownTime = 5f;
    private float minCooldownTime = 0f;

    public bool isTeleporting;
    

    // Start is called before the first frame update
    void Start()
    {
        isTeleporting = false;
    }

    // Update is called once per frame
    void Update()
    {
        PortalCooldown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Portal" && collision.gameObject.name == "PrimaryPortalCenter" && isTeleporting == false)
        {
            player.transform.position = new Vector3(secondaryPortal.transform.position.x, secondaryPortal.transform.position.y, 1); isTeleporting = true;
            
        }
        else if(collision.gameObject.tag == "Portal" && collision.gameObject.name == "SecondaryPortalCenter" && isTeleporting == false)
        {
            player.transform.position = new Vector3(primaryPortal.transform.position.x, primaryPortal.transform.position.y, 1);
            isTeleporting = true;
            
        }
    }

    public void PortalCooldown()
    {
        if(isTeleporting == true)
        {
            cooldownTime -= Time.deltaTime;
            Debug.Log(cooldownTime);

            
        }
        if(cooldownTime <= minCooldownTime)
        {
            PortalReset();
        }
    }

    public void PortalReset()
    {
        isTeleporting = false;
        cooldownTime = 5f;
    }


}
