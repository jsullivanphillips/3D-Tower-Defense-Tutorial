using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns = 5f;
    private float spawnCounter;

    public int amountToSpawn = 15;

    public Castle castle;
    public Path path;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    void Update()
    {
        if(amountToSpawn > 0 && LevelManager.instance.levelActive)
        {
            spawnCounter -= Time.deltaTime;

            if(spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                var newEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
                newEnemy.Setup(castle, path);

                amountToSpawn--;
            }
        }
    }
}
