using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BOI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 5000) == 5)
        {
            Instantiate(BOI);
        }
    }
}
