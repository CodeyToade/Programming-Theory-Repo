using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public MainManager mainManager;

    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainManager.UpdateLife(-1);
        }

        Destroy(gameObject);
    }
}
