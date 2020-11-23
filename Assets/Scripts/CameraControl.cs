using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    public Skybox sky1;
    public Skybox sky2;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        //transform.position = new Vector2(target.transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 10f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }


        if (transform.position.y > 300)
        {
            sky1.enabled = false;
            sky2.enabled = true;
        }
        else
        {
            sky2.enabled = false;
            sky1.enabled = true;
        }
    }
}
