using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //public WaveManager waveManager;
    public Player player;

    public GameObject durabilityVisual;

    public float currentDurability;
    public float maxDurability = 1.5f;
    public float minDurability = 0f;
    public float durabilityRate = .1f;
    public float durabilityFixPerItem = .5f;

    public Button SpawnerSealingButton;

   
    public bool isSealing;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
        isSealing = false;
        currentDurability = maxDurability;
        durabilityVisual.transform.localScale = new Vector3(maxDurability, maxDurability, 0);
    }

    // Update is called once per frame
    void Update()
    {

        EnemySpawnerDurability();

        if(currentDurability >= maxDurability)
        {
            currentDurability = maxDurability;

        }

    }

    

    public void EnemySpawnerDurability()
    {
        if(currentDurability <= minDurability)
        {
            //Instantiate Enemies
            currentDurability = minDurability;
            
        }
        else
        {
            
            currentDurability -= durabilityRate * Time.deltaTime;
            durabilityVisual.transform.localScale = new Vector3(currentDurability, currentDurability, 0);
            
        }
        if (currentDurability >= maxDurability)
        {
            currentDurability = maxDurability;
        }
    }
    

    public void CloseEnemySpawn()
    {
        if (currentDurability < maxDurability && player.currentSealer > 0)
        {

            //Allow to be closed to prevent spawning
            player.currentSealer -= 1;
            currentDurability += durabilityFixPerItem;
            durabilityVisual.transform.localScale = new Vector3(currentDurability, currentDurability, 0);
            
           
            
        }

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SpawnerSealingButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnerSealingButton.gameObject.SetActive(false);
        }
    }

}
