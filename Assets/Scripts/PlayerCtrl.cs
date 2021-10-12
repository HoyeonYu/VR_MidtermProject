using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    GameObject targetArea;
    Rigidbody playerBody;
    public static bool isMovable = false, isSneaking = false;
    float minSpeed = 1f, maxSpeed = 15f, minSneakTime = 4f, maxSneakTime = 7f;
    float speed = 2f, sneakRate, sneakTime, sneakMovingTime = 0.3f;

    void Start()
    {
        targetArea = GameObject.FindGameObjectWithTag("TargetArea");
        playerBody = GetComponent<Rigidbody>();
        sneakRate = Random.Range(minSneakTime, maxSneakTime);
    }

    void Update()
    {
        if (isMovable)
        {
            speed = Random.Range(minSpeed, maxSpeed);
            transform.LookAt(targetArea.transform);
            playerBody.velocity = transform.forward * speed;
        }

        else
        {
            sneakTime += Time.deltaTime;

            if (sneakTime >= sneakRate)
            {
                isSneaking = true;
                transform.LookAt(targetArea.transform);
                playerBody.velocity = transform.forward * speed;
            }

            if (sneakTime - sneakRate >= sneakMovingTime)
            {
                isSneaking = false;
                sneakTime = 0f;
                sneakRate = Random.Range(minSneakTime, maxSneakTime);
            }
        }
    }

    public void normalState()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void gazedState()
    {
        if (isSneaking)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        else
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
