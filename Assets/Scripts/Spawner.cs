using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  private GameObject enemy;
    [SerializeField] private int amountSpawned;

    [SerializeField] private Vector3 [] spawnLocations;



    // Update is called once per frame
    void Start()
    {
        //wait 5s before spawning anything
        Invoke("spawnEnemy", 5f);
        
    }
    void spawnEnemy()
    {
        for (int i = 0; i < amountSpawned; i++)
        {
            Instantiate(enemy, RandomLocation(), Quaternion.identity);

        }
    }

    Vector3 RandomLocation()
    {
        return spawnLocations[Random.Range(0, spawnLocations.Length)];
    }
}
