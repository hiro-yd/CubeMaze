using UnityEngine;

public class PauseManager : MonoBehaviour
{
    GameObject Player;
    GameObject Background;

    public static bool set = false;
    bool a = false;
    public static bool BackGround = false;

    void Start()
    {
        Background = GameObject.Find("Canvas/Pause");
        Player = GameObject.Find("Player_Cube");
        Background.SetActive(false);
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) set = !set;

        if (set == true && a == false)
        {
            SetPanel();
            set = false;
        }
        else if (set == true && a == true)
        {
            ClosePanel();
            set = false;
        }
    }
    void SetPanel()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        Background.SetActive(true);
        BackGround = true;
        a = true;
    }
    public void ClosePanel()
    {
        Player.GetComponent<PlayerController>().enabled = true;
        Background.SetActive(false);
        BackGround = false;
        a = false;
    }
}
