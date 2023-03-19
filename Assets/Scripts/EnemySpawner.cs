using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject durabilityVisual;

    public float currentDurability;
    public float maxDurability = 1.5f;
    public float minDurability = 0f;
    public float durabilityRate = .1f;
    public float durabilityFixPerItem = .5f;

    public Button SpawnerSealingButton;

    public bool isOpen;
    public bool isSealing;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isSealing = false;
        currentDurability = maxDurability;
        durabilityVisual.transform.localScale = new Vector3(maxDurability, maxDurability, 0);
    }

    // Update is called once per frame
    void Update()
    {

        EnemySpawnerDurability();

        if(currentDurability <= minDurability)
        {
            currentDurability = minDurability;
        }

        if(currentDurability > maxDurability)
        {
            currentDurability = maxDurability;
        }

    }

    

    public void EnemySpawnerDurability()
    {
        if(currentDurability <= minDurability && isSealing == false)
        {
            //Instantiate Enemies
            currentDurability = minDurability;
            isOpen = true;
        }
        else
        {
            currentDurability -= durabilityRate * Time.deltaTime;
            durabilityVisual.transform.localScale = new Vector3(currentDurability, currentDurability, 0);
            isOpen = false;
        }
    }
    

    public void CloseEnemySpawn()
    {
        if (currentDurability < maxDurability && isSealing == false)
        {
            
            //Allow to be closed to prevent spawning
            currentDurability += durabilityFixPerItem;
            durabilityVisual.transform.localScale = new Vector3(currentDurability, currentDurability, 0);
            isSealing = true;
            isOpen = false;
        }
        else
        {
            isSealing = false;
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
        SpawnerSealingButton.gameObject.SetActive(false);
    }

}
