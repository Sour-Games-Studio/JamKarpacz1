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
    void spawnEnemy()
    {
        for (int i = 0; i < amountSpawned; i++)
        {
            Instantiate(enemy, spawnLocations[i], Quaternion.identity);
        }
    }
}
