
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField] List<Transform> spawners = new List<Transform>();
    [SerializeField] float spawnInterval = 3;
    [SerializeField] float creepNumber = 3;
    [SerializeField] GameObject creepPrefab;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawners.Add(transform.GetChild(i));
        }

        InvokeRepeating("SpawnCreeps", spawnInterval, spawnInterval);
    }



    void SpawnCreeps()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            for (int j = 0; j < creepNumber; j++)
            {
                SpawnCreepAtSpawner(spawners[i]);
            }

        }
    }

    private void SpawnCreepAtSpawner(Transform spawnPoint)
    {
        GameObject creep = Instantiate(creepPrefab, spawnPoint.position + new Vector3(UnityEngine.Random.Range(0, 4), 0, 0), Quaternion.identity);
        creep.GetComponent<EnemyMove>().path = spawnPoint.gameObject.GetComponent<Spawner>().path;

    }
}
