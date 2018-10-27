using UnityEngine;

public class Scroll : MonoBehaviour
{

    private GameObject MainCamera;

    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float Scroll = Input.GetAxis("Mouse ScrollWheel");

        MainCamera.transform.position += new Vector3(0, Scroll * 750, 0);
        if (MainCamera.transform.position.y >= 0) MainCamera.transform.position = new Vector3(0, 0, 0);
        else if (MainCamera.transform.position.y <= -2925) MainCamera.transform.position = new Vector3(0, -2925, 0);
    }
}