using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardText : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ExecuteAfterTime());

    }


    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene(0, LoadSceneMode.Single);

        // Code to execute after the delay
    }
}
