using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CameraController : MonoBehaviour
{
    public GameObject virtualCam;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(true);
            AstarPath.active.Scan();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(false);
            AstarPath.active.Scan();
        }
    }


}
