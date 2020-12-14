using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //DontDestroyOnLoad(Player);
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }
}
