using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] fallingPrefabs;
    private MainManager mainManager;

    private float spawnRangeX = 19;
    private float spawnRangeZ = 19;

    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        InvokeRepeating("SpawnRandomRocket", startDelay, spawnInterval);
    }

    void SpawnRandomRocket()
    {
        if (!(mainManager.isGameOver))
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 20, Random.Range(-spawnRangeZ, spawnRangeZ));
                int rocketIndex = Random.Range(0, fallingPrefabs.Length);
                Instantiate(fallingPrefabs[rocketIndex], spawnPos, fallingPrefabs[rocketIndex].transform.rotation);
            }
        }
    }
}