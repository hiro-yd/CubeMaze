using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject Player;

    [SerializeField]
    float y;
    [SerializeField]
    float z;

    void Start()
    {
        Player = GameObject.Find("Player_Cube");
    }

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, y, z);
        if (Player.transform.position.z >= 4.5)
        {
            transform.position = new Vector3(Player.transform.position.x, y, Player.transform.position.z-9.5f);
        }
    }
}
