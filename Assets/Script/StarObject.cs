using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject : MonoBehaviour
{

    public static bool StarSound;
    public static bool GetStarCube;
    [SerializeField]
    private Vector3 Vec3;

    void Start()
    {
        GetStarCube = false;
        StarSound = false;
    }

    void Update()
    {
        transform.Rotate(Vec3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StarSound = true;
            GetStarCube = true;
            Destroy(gameObject);
        }
    }
}
