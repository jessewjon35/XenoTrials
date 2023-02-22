using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    public Vector2 rayStart; 

    public GameObject player;

    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayStart, playerController.playerDir, rayDistance);


    }

    
    

}
