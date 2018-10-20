using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCheck : MonoBehaviour
{

    public bool[] star = new bool[3];

    [SerializeField]
    int MoveNorma;

    public static StarCheck Instance;

    #region GameUI
    [Header("Main用")]
    [SerializeField]
    private Sprite TrueStar;
    [SerializeField]
    private Sprite FalseStar;
    [SerializeField]
    private Image Star0;
    [SerializeField]
    private Image Star1;
    [SerializeField]
    private Image Star2;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        star[0] = false;
        star[1] = false;
        star[2] = false;
    }

    public void StarJudge()
    {
        //一個目の星 : クリア
        if (GoalManager.goal == true)
        {
            star[0] = true;
        }

        //二個目の星 : 回数制限
        if (PlayerController.moveCount <= MoveNorma)
        {
            star[1] = true;
        }

        //三個目の星 : スターキューブ取得
        if (StarObject.GetStarCube == true)
        {
            star[2] = true;
        }

        StarDisp();
    }

    void StarDisp()
    {
        if (star[0] == true)
        {
            Star0.GetComponent<Image>().sprite = TrueStar;
        }
        else
        {
            Star0.GetComponent<Image>().sprite = FalseStar;
        }
        if (star[1] == true)
        {
            Star1.GetComponent<Image>().sprite = TrueStar;
        }
        else
        {
            Star1.GetComponent<Image>().sprite = FalseStar;
        }
        if (star[2] == true)
        {
            Star2.GetComponent<Image>().sprite = TrueStar;
        }
        else
        {
            Star2.GetComponent<Image>().sprite = FalseStar;
        }
    }
}
