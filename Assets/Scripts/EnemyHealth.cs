using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Enemy enemy;

    public int enemy1CurrentHealth;
    public int enemy1MinHealth = 0;
    public int enemy1MaxHealth = 50;


    // Start is called before the first frame update
    void Start()
    {
        enemy1CurrentHealth = enemy1MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1CurrentHealth <= enemy1MinHealth)
        {
            enemy1CurrentHealth = enemy1MinHealth;
            Destroy(gameObject);
            enemy.DropRate();
        }
        else if(enemy1CurrentHealth >= enemy1MaxHealth)
        {
            enemy1CurrentHealth = enemy1MaxHealth;
        }

        

    }
}
