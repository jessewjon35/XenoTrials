using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Door door;
    public Objectives objectives;

    public GameObject enemy;

    public TMP_Text nextWaveText;

    public List<Transform> spawnPoints;
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;
    public Transform spawner5;
    public Transform spawner6;

    public float spawnRate;

    public float timeBetweenWaves = 10f;
    public float waveCountdown = 0;

    public float searchCountdown = 1.0f;

    public int enemyCount;

    public int currentWave;
    private int nextWave;

    public bool waveIsDone;
    public bool isSpawning;
    public bool isWaiting;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
        enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        objectives = GameObject.FindGameObjectWithTag("Objectives").GetComponent<Objectives>();
        objectives = GameObject.FindGameObjectWithTag("Objectives").GetComponent<Objectives>();

        currentWave = 0;
        

        spawnPoints.Add(spawner1);
        spawner1.gameObject.SetActive(true);

        spawnPoints.Remove(spawner2);
        spawner2.gameObject.SetActive(false);

        spawnPoints.Remove(spawner3);
        spawner3.gameObject.SetActive(false);

        spawnPoints.Remove(spawner4);
        spawner4.gameObject.SetActive(false);

        spawnPoints.Remove(spawner5);
        spawner5.gameObject.SetActive(false);

        spawnPoints.Remove(spawner6);
        spawner6.gameObject.SetActive(false);

        waveIsDone = true;
        isSpawning = false;


    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(timeBetweenWaves <= waveCountdown)
        {
            timeBetweenWaves = 10f;
        }

        if(waveIsDone == true)
        {
            isWaiting = true;
            WaitingForNextWave();
        }
        else
        {
            EnemyCheck();
            isWaiting = false;
        }
  

    }

    public void WaitingForNextWave()
    {
        
        timeBetweenWaves -= Time.deltaTime;

        nextWaveText.gameObject.SetActive(true);

        if (timeBetweenWaves <= waveCountdown)
        {
            SpawnWave();
            isWaiting = false;
        }
        
    }

    public void SpawnWave()
    {
        nextWaveText.gameObject.SetActive(false);

        nextWave = currentWave + 1;
        currentWave = nextWave;
        Debug.Log(currentWave);

        Debug.Log("Wave Starting");
        if(objectives.navigationSabotaged == false && objectives.communicationSabotaged == false)
        {
            enemyCount += 2;
            spawnRate = .25f;
        }
        else if(objectives.navigationSabotaged == true || objectives.communicationSabotaged == true)
        {
            enemyCount += 3;
            spawnRate = .25f;
        }
        else if (objectives.navigationSabotaged == true && objectives.communicationSabotaged == true)
        {
            enemyCount = 500;
        }


        waveIsDone = false;

        StartCoroutine(SpawnEnemy());
  
    }

    

    IEnumerator SpawnEnemy()
    {
       
        isSpawning = true;
        Debug.Log("Spawning Enemies");

        
        for (int i = 0; i < enemyCount; i++)
        {
        
            Transform sp = spawnPoints[Random.Range(0, spawnPoints.Count)];
            yield return new WaitUntil(() => enemySpawner.currentDurability <= 0);
            GameObject enemyClone = Instantiate(enemy, sp.position, sp.rotation);
            yield return new WaitForSeconds(1 / spawnRate);
            
        }

        isSpawning = false;

        
        
    }

    
    

    public void EnemyCheck()    
    {
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0 && isSpawning == false)
        {


            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                waveIsDone = true;
                WaveCompleted();

            }
            else
            {

                waveIsDone = false;
                
            }

            searchCountdown = 1;

        }


    }

    public void WaveCompleted()
    {
        Debug.Log("WaveCompleted");
        waveIsDone = true;
        currentWave = nextWave;
        

    }

    public void SpawnerActivating()
    {
        if (door.roomThreeUnlocked == true)
        {
            spawnPoints.Add(spawner2);
            spawner2.gameObject.SetActive(true);
        }
        if (door.roomFourUnlocked == true)
        {
            spawnPoints.Add(spawner3);
            spawner3.gameObject.SetActive(true);
        }
        if (door.roomThreeAUnlocked == true)
        {
            spawnPoints.Add(spawner4);
            spawner4.gameObject.SetActive(true);
        }
        if (door.roomTwoAUnlocked == true)
        {
            spawnPoints.Add(spawner5);
            spawner5.gameObject.SetActive(true);
        }
        if (door.communicationUnlocked == true)
        {
            spawnPoints.Add(spawner6);
            spawner6.gameObject.SetActive(true);
        }
    }

}
