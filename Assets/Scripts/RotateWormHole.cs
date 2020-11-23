using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWormHole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform tpLoc;
    public GameObject Bongcloud;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = tpLoc.position;
            Bongcloud.GetComponent<GroundDetection>().OK = 0.05f;
        }
    }
}
