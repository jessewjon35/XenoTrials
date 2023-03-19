using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public Pistol pistolScript;

    public GameObject pistol;
    public GameObject shotgun;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        FindClosestEnemy();

        
           
    }

    public void FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        if(allEnemies != null)
        {

            foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

                //Vector3 difference = closestEnemy.transform.position - transform.position;
                //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                //pistol.transform.rotation = Quaternion.Euler(0, 0, rotZ);


            }
            
            
        }
        }

        

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

    }

}
