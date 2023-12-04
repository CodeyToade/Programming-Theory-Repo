using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] rocketPrefabs;
    private MainManager mainManager;

    [SerializeField] private float spawnRangeX = 24;
    [SerializeField] private float spawnRangeZ = 24;

    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        InvokeRepeating("SpawnRandomRocket", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomRocket()
    {
        if (!(mainManager.isGameOver))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 20, Random.Range(-spawnRangeZ, spawnRangeZ));
            int rocketIndex = Random.Range(0, rocketPrefabs.Length);
            Instantiate(rocketPrefabs[rocketIndex], spawnPos, rocketPrefabs[rocketIndex].transform.rotation);
        }
    }
}