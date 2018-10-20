using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    
    [SerializeField]
    Material Red;
    [SerializeField]
    Material Blue;
    [SerializeField]
    Material Green;
    [SerializeField]
    Material Pink;
    [SerializeField]
    Material LightBlue;
    [SerializeField]
    Material Yellow;

    public static bool isWater = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            isWater = true;

            if (other.gameObject.tag == "Red")
            {
                other.gameObject.GetComponent<Renderer>().material = Red;
            }

            if (other.gameObject.tag == "Blue")
            {
                other.gameObject.GetComponent<Renderer>().material = Blue;
            }

            if (other.gameObject.tag == "Green")
            {
                other.gameObject.GetComponent<Renderer>().material = Green;
            }

            if (other.gameObject.tag == "Pink")
            {
                other.gameObject.GetComponent<Renderer>().material = Pink;
            }

            if (other.gameObject.tag == "Yellow")
            {
                other.gameObject.GetComponent<Renderer>().material = Yellow;
            }

            if (other.gameObject.tag == "LightBlue")
            {
                other.gameObject.GetComponent<Renderer>().material = LightBlue;
            }
        }
    }
}
