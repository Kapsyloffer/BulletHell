using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField]Transform Enemy;
    [SerializeField]Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float nextSpawn = 0;
    int SpawnCounter = 0;
    void FixedUpdate()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + 2f;
            SpawnCounter++;
            Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
        }
        /*if(SpawnCounter >= 10)
        {
            nextSpawn = Time.time + 10f;
            SpawnCounter = 0;
        }*/
        Debug.Log(SpawnCounter);
    }

    void SpawnEnemy()
    {

    }
}
