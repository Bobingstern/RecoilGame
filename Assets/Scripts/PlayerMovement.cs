using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Camera veiw;
    public float joltSpeed;
    private Vector3 mousecords = new Vector3(0, 0, 0);
    public bool canYeet;
    public int ammo = 2;
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;
    public bool click;
    public GameObject Bongcloud;
    public GameObject Red;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject p;
    public bool paused;
    public int[] potsto;
    public float volume;
    public Slider vol;
    public Slider volSFX;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        string p = Application.persistentDataPath + "/newgame.recoil";
        
        
        

        if (File.Exists(p))
        {
            potsto = new int[1];
            BinaryFormatter formatte = new BinaryFormatter();
            FileStream strea = new FileStream(p, FileMode.Open);
            potsto = formatte.Deserialize(strea) as int[];
            
            strea.Close();
        }
        
        
        string path = Application.persistentDataPath + "/player.recoil";

        if (File.Exists(path))
        {
            if (potsto[0] == 1)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                float[] data = formatter.Deserialize(stream) as float[];
                transform.position = new Vector2(data[0], data[1]);
                stream.Close();
            }
        }

        string pot = Application.persistentDataPath + "/volume.recoil";

        if (File.Exists(pot))
        {
            
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(pot, FileMode.Open);
                float[] data = formatter.Deserialize(stream) as float[];
                vol.value = data[0];
                stream.Close();
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        volume = vol.value;
        audio.volume = volume;
        audio2.volume = volume;
        audio.volume = volume;
        audio3.volume = volSFX.value;
        paused = p.GetComponent<Pause>().paused;


        if (!paused)
        {

            if (transform.position.y < 50)
            {
                Bongcloud.GetComponent<GroundDetection>().OK = 0.15f;
            }
            else
            {
                Bongcloud.GetComponent<GroundDetection>().OK = 0.05f;
            }



            if (canYeet)
            {
                ammo = 1;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (ammo > 0)
                {

                    if (!canYeet)
                    {
                        ammo--;
                    }
                    click = false;
                    audio.Play(0);
                    this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    var pos = veiw.ScreenToWorldPoint(Input.mousePosition);

                    Vector3 reverseVector = new Vector3(pos.x * -1, pos.y * -1, pos.z);

                    var dir = reverseVector - new Vector3(transform.position.x * -1, transform.position.y * -1, transform.position.z);
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    this.GetComponent<Rigidbody2D>().AddForce(transform.right * joltSpeed);
                }
                else
                {

                    click = true;
                    audio2.Play(0);
                }
            }


            if (ammo > 0)
            {
                if (canYeet == true)
                {
                    Green.SetActive(true);
                    Red.SetActive(false);
                    Yellow.SetActive(false);
                }
                else if (ammo == 1)
                {
                    Red.SetActive(false);
                    Yellow.SetActive(true);
                    Green.SetActive(false);
                }

            }
            else
            {
                Red.SetActive(true);
                Green.SetActive(false);
                Yellow.SetActive(false);
            }



        }




    }

    IEnumerator LateCall(float sec)
    {
        
        yield return new WaitForSeconds(sec);

        ammo = 1;
        //Do Function here...
        StopAllCoroutines();
    }

    


}
