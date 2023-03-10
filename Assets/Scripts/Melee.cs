using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public PlayerUI playerUi;
    public Player playerScript;
    

    private GameObject enemyClone;

    public GameObject currency;

    public ParticleSystem enemyDeathEffect;
      
    public float meleeRange = .5f;
    public float timeBetweenMelee;
    public float meleeStartTime;
    
    //public float dropChance = .75f;
    public int currencyPerMelee = 15;

    public Transform meleepoint;
    
    public LayerMask enemyLayers;

    public bool meleeButtonPressed;
    public bool meleeAllowed;


    // Start is called before the first frame update
    void Start()
    {
        meleeButtonPressed = false;
        meleeAllowed = true;

        timeBetweenMelee = meleeStartTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyClone = GameObject.FindWithTag("Enemy");

        if(timeBetweenMelee <= 0)
        {
            meleeAllowed = true;
        }
        else
        {
            meleeAllowed = false;
            timeBetweenMelee -= Time.deltaTime;
        }
    }

    public void MeleeAttack()
    {
        if (meleeAllowed == true)
        {
            timeBetweenMelee = meleeStartTime;
            meleeAllowed = false;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleepoint.position, meleeRange, enemyLayers);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("Attack hit!");

                //DropRate();

                Destroy(obj: enemyClone);

                playerScript.currentCurrency += currencyPerMelee;


                //enemyDeathEffect.Play();

                
                

            }
        }

        
      

}

    private void OnDrawGizmosSelected()
    {
        if (meleepoint == null)
            return;
        Gizmos.DrawWireSphere(meleepoint.position, meleeRange);
    }

    /*public void DropRate()
    {
        if (Random.Range(0f, 1f) <= dropChance)
        {
            Instantiate(currency, this.transform.position, Quaternion.identity);
        }

    }*/




}
