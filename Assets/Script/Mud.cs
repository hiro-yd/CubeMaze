using UnityEngine;

public class Mud : MonoBehaviour
{

    [SerializeField]
    Material mud;

    public static bool IsMud = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            IsMud = true;
            other.gameObject.GetComponent<Renderer>().material = mud;

        }
    }
}
