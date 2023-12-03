using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] rocketPrefabs;
    private MainManager mainManager;

    private float spawnRangeX = 1;
    private float spawnRangeZ = 1;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 20, Random.Range(-spawnRangeZ, spawnRangeZ));
            int rocketIndex = Random.Range(0, rocketPrefabs.Length);
            Instantiate(rocketPrefabs[rocketIndex], spawnPos, rocketPrefabs[rocketIndex].transform.rotation);
        }
    }
}