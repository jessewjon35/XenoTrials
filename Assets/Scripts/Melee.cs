using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public PlayerUI playerUi;
    public Player playerScript;
    

    private GameObject enemyClone;

    public GameObject currency;
      
    public float meleeRange = .5f;
    //public float dropChance = .75f;
    public float currencyPerMelee = 15f;

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

            //DropRate();

            Destroy(obj: enemyClone);

            playerScript.currentCurrency += currencyPerMelee;
            



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
