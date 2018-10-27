using UnityEngine;

public class RayManager : MonoBehaviour {

    #region Ray
    public Ray Rightray;
    public Ray Leftray;
    public Ray Upray;
    public Ray Downray;
    #endregion

    public static RayManager Instance;

    GameObject Player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start ()
    {
        Player = GameObject.Find("Player_Cube");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rightray = new Ray(Player.transform.position, new Vector3(1, 0, 0));
        Leftray = new Ray(Player.transform.position, new Vector3(-1, 0, 0));
        Upray = new Ray(Player.transform.position, new Vector3(0, 0, 1));
        Downray = new Ray(Player.transform.position, new Vector3(0, 0, -1));
    }
}
