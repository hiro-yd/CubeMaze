using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField, Tooltip("同期させるColorJudgeを入れる")]
    ColorJudge Cj;

    [SerializeField]
    private GameObject[] wall;

    bool isMove = false;
    bool isUse = false;

    void Update()
    {
        if (isMove) MoveWall();
        if (isUse) return;
        if (Cj.judge)
        {
            isMove = true;
        }
    }
    void MoveWall()
    {
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].transform.position += new Vector3(0, -0.1f, 0);
            if (wall[i].transform.position.y <= -0.5)
            {
                wall[i].transform.position = new Vector3(wall[i].transform.position.x,-0.5f,wall[i].transform.position.z);
                isMove = false; isUse = true;
            }
        }
    }
}
