using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FucckUpTheGravity : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public Camera Boi;
    public GameObject Targ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Targ.transform.position = new Vector2(Player.transform.position.x, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Boi.GetComponent<CameraControl>().target = Targ;
        Player.GetComponent<Rigidbody2D>().gravityScale = -0.01f;
    }
}
