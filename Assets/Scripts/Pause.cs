using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public bool paused;
    public GameObject penal;
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                penal.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                penal.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
