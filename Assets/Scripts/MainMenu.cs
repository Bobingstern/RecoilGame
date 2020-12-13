using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public float[] position;
    public GameObject player;
    public GameObject New;
    public GameObject Cont;
    public int[] bong;
    public Slider volume;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string path = Application.persistentDataPath + "/player.recoil";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            float[] data = formatter.Deserialize(stream) as float[];
            Cont.SetActive(true);
            stream.Close();
        }
        else
        {
            Cont.SetActive(false);
        }


    }

    public void NewGame()
    {
        string path = Application.persistentDataPath + "/newgame.recoil";

        bong = new int[1];
        bong[0] = 0;
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bong);
        stream.Close();

        SceneManager.LoadScene(1, LoadSceneMode.Single);



    }

    public void Quit()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
        if (player != null)
        {

            position = new float[2];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.recoil";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, position);
            stream.Close();

        }

        if (volume != null)
        {

            position = new float[1];
            position[0] = volume.value;
            

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/volume.recoil";
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, position);
            stream.Close();

        }

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/newgame.recoil";

        bong = new int[1];
        bong[0] = 1;
        BinaryFormatter formatter = new BinaryFormatter();
            
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bong);
        stream.Close();
        SceneManager.LoadScene(1, LoadSceneMode.Single);



    }

    public void Leave()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void EE()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
