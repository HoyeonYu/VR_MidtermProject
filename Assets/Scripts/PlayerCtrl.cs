using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    GameObject targetArea;
    Rigidbody playerBody;
    public static bool isMovable = false, isSneaking = false;
    float minSpeed = 1f, maxSpeed = 15f, minSneakTime = 3f, maxSneakTime = 5f;
    float speed = 2f, sneakRate, sneakTime, sneakMovingTime = 1.5f;

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
                Debug.Log("Sneaking");
                isSneaking = true;
                transform.LookAt(targetArea.transform);
                playerBody.velocity = transform.forward * speed;
                sneakRate = Random.Range(minSneakTime, maxSneakTime);
            }

            if (sneakTime - sneakRate >= sneakMovingTime)
            {
                sneakTime = 0f;
                isSneaking = false;
            }
        }
    }
}
