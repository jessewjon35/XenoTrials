using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{

    public enum SpawnState { Spawning, Waiting, Counting }


    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;
    }

    //public Wave wave;
    public Wave[] waves;
    private int nextWave = 0;
    //private int previousWave;
    private int currentWave;
    //private int waveMultiplier = 2;
   

    //public GameObject roomThreeVCam;
    //public GameObject roomFiveVCam;
    //public GameObject roomSixVCam;
    //public GameObject roomSevenVCam;

    //public Transform[] spawnPoints;
    //public List<Transform> spawnPoints;

    public List<Transform> spawnPoints = new List<Transform>();
    public Transform roomOneSpawnPoint;
    public Transform roomThreeSpawnPoint;
    public Transform roomFiveSpawnPoint;
    public Transform roomSixSpawnPoint;
    public Transform roomSevenSpawnPoint;

    public float timeBetweenWaves = 10f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public bool spawner3Active;
    public bool spawner5Active;
    public bool spawner6Active;
    public bool spawner7Active;

    private SpawnState state = SpawnState.Counting;

    public TMP_Text timeBetweenWavesText;

    private void Start()
    {
        currentWave = nextWave + 1;

        //timeBetweenWavesText.text = "T- 10 Seconds Until " + wave.name;
        timeBetweenWavesText.gameObject.SetActive(false);

        spawner3Active = false;
        spawner5Active = false;
        spawner6Active = false;
        spawner7Active = false;
        
        


        if (spawnPoints.Count == 0)
        {
            Debug.LogError("No Spawn Points referenced");
        }

        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        currentWave = nextWave + 1;

        if (state == SpawnState.Waiting)
        {
            if(!EnemyisAlive())
            {
                //Begin new round
                WaveCompleted();
                

                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            timeBetweenWavesText.gameObject.SetActive(false);

            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            timeBetweenWavesText.gameObject.SetActive(true);
            timeBetweenWavesText.text = "T- 10 Seconds Until Wave " + currentWave;
            waveCountdown -= Time.deltaTime;
        }

        ActivateSpawners();

    }
    public void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete!");
        }
        else
        {

            nextWave++;  
            
        }

    }


    public bool EnemyisAlive()
    {
        searchCountdown -= Time.deltaTime;

        if(searchCountdown <= 0)
        {
            searchCountdown = 1f;
            

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {                
                return false;
            }
        }

        return true;

    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.Spawning;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        
        //Spawn enemy
        Debug.Log("Spawning: " + enemy.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemy, sp.position, sp.rotation);
       
    }

    public void ActivateSpawners()
    {
        /*if(roomThreeVCam.activeSelf == true && spawner3Active == false)
        {
            spawnPoints.Add(roomThreeSpawnPoint);
            spawner3Active = true;
        }

        if (roomFiveVCam.activeSelf == true && spawner5Active == false)
        {
            spawnPoints.Add(roomFiveSpawnPoint);
            spawner5Active = true;
        }

        if (roomSixVCam.activeSelf == true && spawner6Active == false)
        {  
            spawnPoints.Add(roomSixSpawnPoint);
            spawner6Active = true;
        }

        if (roomSevenVCam.activeSelf == true && spawner7Active == false)
        {
            spawnPoints.Add(roomSevenSpawnPoint);
            spawner7Active = true;
        }*/
    }
    

}
