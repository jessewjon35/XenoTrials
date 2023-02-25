using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

    private GameObject enemyClone;
      
    public float meleeRange = .5f;

    public Transform meleepoint;
    
    public LayerMask enemyLayers;

    public bool meleeButtonPressed;


    // Start is called before the first frame update
    void Start()
    {
        meleeButtonPressed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyClone = GameObject.FindWithTag("Enemy");
    }

    public void MeleeAttack()
    {       
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleepoint.position, meleeRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Attack hit!");

            Destroy(obj: enemyClone); 

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (meleepoint == null)
            return;
        Gizmos.DrawWireSphere(meleepoint.position, meleeRange);
    }






}
