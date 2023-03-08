using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    

    //private Vector2 rayStart;
    //private Vector2 rayDirection;

    //private GameObject potentialTarget;
    //private Transform closestTarget;

    //private float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        

        //rayStart = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {


        


    }

    public void FindClosestEnemy()
    {
        //potentialTarget = GameObject.FindWithTag("Enemy");
        //closestTarget = null;

        

    }

    /*Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }*/

    
    

}
