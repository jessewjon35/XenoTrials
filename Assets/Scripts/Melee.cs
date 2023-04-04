using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public PlayerUI playerUi;
    public Player playerScript;
   
    //public GameObject starterMelee;
    //public GameObject currency;
    

    public ParticleSystem enemyDeathEffect;
    
    public float timeBetweenMelee;
    public float disableMeleeTime;
    

    public int meleeDamage = 25;
    public int currencyPerMelee = 15;

    public bool meleeAllowed;
   
    public CircleCollider2D meleeCol;
    
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>();
        meleeCol = GetComponent<CircleCollider2D>();
        

        
       
        meleeCol.enabled = false;

        
        meleeAllowed = true;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MeleeReset()
    {
        meleeAllowed = false;
        meleeCol.enabled = true;
        yield return new WaitForSeconds(disableMeleeTime);
        meleeCol.enabled = false;

        yield return new WaitForSeconds(timeBetweenMelee);
        meleeAllowed = true;
    }

    public void MeleeAttack()
    {


        if (meleeAllowed == true)
        {

            StartCoroutine(MeleeReset());
            

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
