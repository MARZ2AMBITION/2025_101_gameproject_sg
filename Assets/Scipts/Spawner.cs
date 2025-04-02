using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject coinPrefabs;
    public GameObject misslePrefabs;
        
    [Header("스폰 타이밍설정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    [Range(0, 100)]
    public float coinSpawnChance =50;


    public float timer = 0.0f;
    public float nextSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        SetNextSpwwnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= nextSpawnTimer)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpwwnTime();
        }
    }
    
    void SpawnObject()
    {
        Transform spawnPosition = transform;
        int randomValue = Random.Range(0, 100);
        if (randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnPosition.position, spawnPosition.rotation);
        }
        else
        {
            Instantiate(misslePrefabs, spawnPosition.position, spawnPosition.rotation);
        }
    }

   void SetNextSpwwnTime()
   {
       nextSpawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
   }
}
