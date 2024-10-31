using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerscripr : MonoBehaviour
{
    public List<enemy> enemies = new List<enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    public float spawnRadius = 50f;
    public Vector2 centerPosition = Vector2.zero;
    public int waveDuration;
    private float spawnInterval;
    private float spawnTimer;
    public Text WaveText;


    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    private void Update()
    {
        WaveText.text = "Wave: " + currWave;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <=0)
        {
            // spawn an enemy
            if(enemiesToSpawn.Count > 0)
            {
                centerPosition = spawnLocation.position;
                Vector2 randomSpawn = Random.insideUnitSphere * spawnRadius;
                Vector2 spawnPosition = randomSpawn + centerPosition;
                Instantiate(enemiesToSpawn[0], spawnPosition, Quaternion.identity); // spawn first enemy in the list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnTimer = spawnInterval;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            
        }
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemy
       
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].Chance;

            if(waveValue-randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class enemy
{
    public GameObject enemyPrefab;
    public int Chance;
}