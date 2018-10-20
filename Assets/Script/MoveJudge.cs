using UnityEngine;

public class MoveJudge : MonoBehaviour {

    public enum Type
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3
    }

    private GameObject Player;

    #region Bool
    public static bool upjudge = false;
    public static bool downjudge = false;
    public static bool rightjudge = false;
    public static bool leftjudge = false;
    #endregion

    public Type type;


    private void Start()
    {
        Player = GameObject.Find("Player_Cube");
    }

    void Update ()
    {
        #region if type
        if (type == Type.Up)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 0.5f);
        }
        if (type == Type.Down)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 0.5f);
        }
        if (type == Type.Right)
        {
            transform.position = new Vector3(Player.transform.position.x + 0.5f, Player.transform.position.y, Player.transform.position.z);
        }
        if (type == Type.Left)
        {
            transform.position = new Vector3(Player.transform.position.x - 0.5f, Player.transform.position.y, Player.transform.position.z);
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        #region if typre
        if (type == Type.Up)
        {
            if(other.gameObject.tag == "Wall")
            {
                upjudge = true;
            }
        }
        if (type == Type.Down)
        {
            if (other.gameObject.tag == "Wall")
            {
                downjudge = true;
            }
        }
        if (type == Type.Right)
        {
            if (other.gameObject.tag == "Wall")
            {
                rightjudge = true;
            }
        }
        if (type == Type.Left)
        {
            if (other.gameObject.tag == "Wall")
            {
                leftjudge = true;
            }
        }
        #endregion
    }

    private void OnTriggerExit(Collider other)
    {
        #region if type
        if (type == Type.Up)
        {
            if (other.gameObject.tag == "Wall")
            {
                upjudge = false;
            }
        }
        if (type == Type.Down)
        {
            if (other.gameObject.tag == "Wall")
            {
                downjudge = false;
            }
        }
        if (type == Type.Right)
        {
            if (other.gameObject.tag == "Wall")
            {
                rightjudge = false;
            }
        }
        if (type == Type.Left)
        {
            if (other.gameObject.tag == "Wall")
            {
                leftjudge = false;
            }
        }
    #endregion
    }
}
