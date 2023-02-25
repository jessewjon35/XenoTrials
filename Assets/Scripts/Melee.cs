using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject meleeWeapon;
    public GameObject enemyPrefab;
    private GameObject enemyClone;

    public float meleeDamage;

    public bool meleeButtonPressed;


    // Start is called before the first frame update
    void Start()
    {
        meleeButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeleeAttack()
    {
        
        meleeButtonPressed = true;
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Melee" && meleeButtonPressed == true)
        {
            if(gameObject.name == "Enemy(Clone)")
            {
                Destroy(gameObject);
            }
            
        }
    }


}
