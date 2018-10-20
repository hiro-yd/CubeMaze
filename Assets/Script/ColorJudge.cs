using UnityEngine;

public class ColorJudge : MonoBehaviour
{

    #region GameObject
    private GameObject Yellow;
    private GameObject Red;
    private GameObject Green;
    private GameObject Pink;
    private GameObject Blue;
    private GameObject LightBlue;
    #endregion
    
    public bool judge = false;

    public enum Color
    {
        yellow = 0,
        red = 1,
        green = 2,
        pink = 3,
        blue = 4,
        LightBlue = 5
    }

    [SerializeField]
    private Color color;

    private void Start()
    {
        #region Find
        Yellow = GameObject.Find("Yellow");
        Red = GameObject.Find("Red");
        Green = GameObject.Find("Green");
        Pink = GameObject.Find("Pink");
        Blue = GameObject.Find("Blue");
        LightBlue = GameObject.Find("LightBlue");
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yellow")
        {
            if (color == Color.yellow)
            {
                judge = true;
            }
        }
        if (other.gameObject.tag == "Pink")
        {
            if (color == Color.pink)
            {
                judge = true;
            }
        }
        if (other.gameObject.tag == "Green")
        {
            if (color == Color.green)
            {
                judge = true;
            }
        }
        if (other.gameObject.tag == "Red")
        {
            if (color == Color.red)
            {
                judge = true;
            }
        }
        if (other.gameObject.tag == "Blue")
        {
            if (color == Color.blue)
            {
                judge = true;
            }
        }
        if (other.gameObject.tag == "LightBlue")
        {
            if (color == Color.LightBlue)
            {
                judge = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Yellow")
        {
            judge = false;
        }
        if (other.gameObject.tag == "Pink")
        {
            judge = false;
        }
        if (other.gameObject.tag == "Green")
        {
            judge = false;
        }
        if (other.gameObject.tag == "Red")
        {
            judge = false;
        }
        if (other.gameObject.tag == "Blue")
        {
            judge = false;
        }
        if (other.gameObject.tag == "LightBlue")
        {
            judge = false;
        }
    }
}
