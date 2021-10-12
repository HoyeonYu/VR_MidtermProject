using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public GameObject playerPrefab;
    int playerTotalNum = 10;

    void Start()
    {
        for (int i = 0; i < playerTotalNum; i++)
        {
            GameObject player = Instantiate(playerPrefab) as GameObject;
            float radian = Random.Range(0, 360) / Mathf.PI;
            float radius = Random.Range(50, 65);
            float xPos = Mathf.Cos(radian) * radius;
            float zPos = Mathf.Sin(radian) * radius;
            player.transform.position = new Vector3(xPos, 2, zPos);
        }
    }
}
