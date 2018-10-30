using UnityEngine;
using UnityEngine.UI;

public class StarCheck : MonoBehaviour
{
    public bool[] star = new bool[3];

    [SerializeField]
    int MoveNorma;

    public int animstar;

    public static StarCheck Instance;

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
            animstar += 1;
            star[0] = true;
        }

        //二個目の星 : 回数制限
        if (PlayerController.moveCount <= MoveNorma)
        {
            animstar += 10;
            star[1] = true;
        }

        //三個目の星 : スターキューブ取得
        if (StarObject.GetStarCube == true)
        {
            animstar += 100;
            star[2] = true;
        }

        GoalAnimation.Instance.Star();
    }
}
