using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boi;
    // Put the prefab of the ground here
    public LayerMask groundLayer;
    public float OK;
    void Start()
    {
        OK = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(boi.transform.position.x, boi.transform.position.y-0.26f);
        boi.GetComponent<PlayerMovement>().canYeet = Physics2D.OverlapCircle(transform.position, OK, groundLayer);

        if (boi.GetComponent<PlayerMovement>().canYeet)
        {
            boi.GetComponent<PlayerMovement>().ammo = 1;
        }
    }

    


}
