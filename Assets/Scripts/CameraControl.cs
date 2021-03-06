﻿using System.Collections;
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
    public GameObject sky;
    public GameObject sky1;

    public Camera me;
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

        float dist = Vector2.Distance(transform.position, target.transform.position);
        if (dist > 5)
        {
            me.orthographicSize = dist;
        }
        


        if (transform.position.y > 300)
        {
            sky.SetActive(true);
            sky1.SetActive(false);
        }
        else
        {
            sky1.SetActive(true);
            sky.SetActive(false);
        }
    }
}
