using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] fallingPrefabs;
    private MainManager mainManager;

    private float spawnRangeX = 9;
    private float spawnRangeZ = 9;

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
                int fallingIndex = Random.Range(0, fallingPrefabs.Length);
                Instantiate(fallingPrefabs[fallingIndex], spawnPos, fallingPrefabs[fallingIndex].transform.rotation);
            }
        }
    }
}