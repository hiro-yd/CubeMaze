using System.Collections;
using System.Collections.Generic;
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
            wall[i].transform.position += new Vector3(0, -0.1f, 0);
        if (wall[0].transform.position.y < -0.5)
            isMove = false; isUse = true;
    }
}
