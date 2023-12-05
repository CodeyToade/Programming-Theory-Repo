using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private MainManager mainManager;

    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainManager.UpdateLife(-1);
        }

        Destroy(gameObject);
    }
}
