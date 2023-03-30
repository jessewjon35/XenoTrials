using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public PlayerUI playerUi;
    public Player playerScript;
   
    public GameObject starterMelee;
    public GameObject currency;
    

    public ParticleSystem enemyDeathEffect;
    
    public float timeBetweenMelee;
    public float meleeStartTime;

    public int meleeDamage = 25;
    public int currencyPerMelee = 15;

    public bool meleeAllowed;
   
    public CircleCollider2D starterMeleeCol;
    
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>();
        starterMeleeCol = GetComponent<CircleCollider2D>();
        

        
       
        starterMeleeCol.enabled = false;

        
        meleeAllowed = true;

        timeBetweenMelee = meleeStartTime;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(timeBetweenMelee <= 0)
        {
            meleeAllowed = true;
            starterMeleeCol.enabled = false;
        }
        else
        {
            meleeAllowed = false;
            starterMeleeCol.enabled = true;
            timeBetweenMelee -= Time.deltaTime;
        }
    }

    public void MeleeAttack()
    {


        if (meleeAllowed == true)
        {
            timeBetweenMelee = meleeStartTime;                  
        }

    }


    /*private void OnDrawGizmosSelected()
    {
        if (meleepoint == null)
            return;
        Gizmos.DrawWireSphere(meleepoint.position, meleeRange);
    }*/

    /*public void DropRate()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            Instantiate(currency, this.transform.position, Quaternion.identity);
        }

    }*/




}
