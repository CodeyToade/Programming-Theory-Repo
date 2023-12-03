using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField] private float yRange = 0;
    private MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yRange)
        {
            Destroy(gameObject);
        }
    }
}
