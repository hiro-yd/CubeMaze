using UnityEngine;

public class Ice : MonoBehaviour
{
    // Ray ray;

    RaycastHit hit;

    float distance;

    LayerMask mask;

    Vector3 Horizontal = new Vector3(1, 0, 0);
    Vector3 Vertical = new Vector3(0, 0, 1);

    GameObject Player;

    bool isSlip;
    public static bool Return;

    string input = null;
    string LayerName = "Wall";

    float time;

    public static Ice Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Player = GameObject.Find("Player_Cube");
        mask = LayerMask.GetMask(new string[] { LayerName });
    }

    void Update()
    {
        if (isSlip)
        {
            Return = true;
            Player.GetComponent<PlayerController>().enabled = false;
            time += Time.deltaTime;
            if (time >= 0.15f)
            {
                Slip();
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
            input = "a";
        if (Input.GetKeyDown(KeyCode.D))
            input = "d";
        if (Input.GetKeyDown(KeyCode.W))
            input = "w";
        if (Input.GetKeyDown(KeyCode.S))
            input = "s";
    }

    void Slip()
    {
        if (input == "d")
        {
            Player.transform.position += Horizontal;
            if (Physics.Raycast(RayManager.Instance.Rightray, out hit, 100.0f, mask))
            {
                distance = hit.distance;
                if (distance <= 0.6f)
                {
                    Player.transform.position -= Horizontal;
                    time = 0;
                    Player.GetComponent<PlayerController>().enabled = true;
                    Return = false;
                    isSlip = false;
                }
            }
        }
        if (input == "a")
        {
            Player.transform.position -= Horizontal;
            if (Physics.Raycast(RayManager.Instance.Leftray, out hit, 100.0f, mask))
            {
                distance = hit.distance;
                if (distance <= 0.6f)
                {
                    Player.transform.position += Horizontal;
                    time = 0;
                    Player.GetComponent<PlayerController>().enabled = true;
                    Return = false;
                    isSlip = false;
                }
            }
        }
        if (input == "w")
        {
            Player.transform.position += Vertical;
            if (Physics.Raycast(RayManager.Instance.Upray, out hit, 100.0f, mask))
            {
                distance = hit.distance;
                if (distance <= 0.6f)
                {
                    Player.transform.position -= Vertical;
                    time = 0;
                    Player.GetComponent<PlayerController>().enabled = true;
                    Return = false;
                    isSlip = false;
                }
            }
        }
        if (input == "s")
        {
            Player.transform.position -= Vertical;
            if (Physics.Raycast(RayManager.Instance.Downray, out hit, 100.0f, mask))
            {
                distance = hit.distance;
                if (distance <= 0.6f)
                {
                    Player.transform.position += Vertical;
                    time = 0;
                    Player.GetComponent<PlayerController>().enabled = true;
                    Return = false;
                    isSlip = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Return)
        {
            if (other.gameObject.tag == "Player")
            {
                isSlip = true;
            }
        }
    }
}
