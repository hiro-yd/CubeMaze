using UnityEngine;

public class Portal : MonoBehaviour{

    [SerializeField, Tooltip("同期させるColorJudgeを入れる")]
    ColorJudge Cj;

    GameObject Player;

    [SerializeField]
    GameObject Effect;
     
    float time;

    private void Start()
    {
        Player = GameObject.Find("Player_Cube");
    }

    void Update()
    {
        if (Cj.judge)
        {
            Effect.SetActive(true);
            time += Time.deltaTime;
            Player.GetComponent<PlayerController>().enabled = false;
            if (time >= 1.5f)
            {
                Teleport();
                time = 0;
                Player.GetComponent<PlayerController>().enabled = true;
                Cj.judge = false;
            }
        }
        else Effect.SetActive(false);
    }
    void Teleport()
    {
        Player.transform.position = transform.position;
    }
}
