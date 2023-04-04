using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{

    public Objectives objectives;

    public GameObject player;
    public GameObject primaryPortal;
    public GameObject secondaryPortal;

    public Button portalButton;

    private float cooldownTime;
    private float minCooldownTime = 0f;

    public bool isTeleporting;
    public bool portalActivated;
    

    // Start is called before the first frame update
    void Start()
    {
        

        isTeleporting = false;
        portalActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectives.navigationRepaired == true)
        {
            cooldownTime = 30;
        }
        else if(objectives.navigationSabotaged == true)
        {
            cooldownTime = 15;
        }

        PortalCooldown();
    }

    public void TeleportToPrimaryPortal()
    {
        player.transform.position = new Vector3(primaryPortal.transform.position.x, primaryPortal.transform.position.y, 1);
        isTeleporting = true;
    }
    public void TeleportToSecondaryPortal()
    {
        player.transform.position = new Vector3(secondaryPortal.transform.position.x, secondaryPortal.transform.position.y, 1);
        isTeleporting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Portal" && collision.gameObject.name == "PrimaryPortalCenter" && isTeleporting == false && portalActivated == true)
        {
            portalButton.gameObject.SetActive(true);
            
        }
        else if(collision.gameObject.tag == "Portal" && collision.gameObject.name == "SecondaryPortalCenter" && isTeleporting == false && portalActivated == true)
        {
            portalButton.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.name == "PrimaryPortalCenter" && isTeleporting == false && portalActivated == true)
        {
            portalButton.gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "Player" && collision.gameObject.name == "SecondaryPortalCenter" && isTeleporting == false && portalActivated == true)
        {
            portalButton.gameObject.SetActive(false);

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
        cooldownTime = 30f;
    }


}
