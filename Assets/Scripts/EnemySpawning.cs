using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    

    private Vector3 spawnLocation;
    
    [SerializeField]
    private float timeBetweenSpawn;


    

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        
        StartCoroutine(spawnEnemies(timeBetweenSpawn, enemyPrefab));
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnLocation, Quaternion.identity);
        StartCoroutine(spawnEnemies(interval, enemy));
    }
}
