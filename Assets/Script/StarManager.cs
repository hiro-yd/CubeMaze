using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    #region StageSelectUI
    [Header("StageSelect用")]
    [SerializeField]
    private Sprite OnLamp;
    [SerializeField]
    private Sprite OffLamp;
    #endregion

    int StarCount;

    public bool[,] GetStar;

    public static StarManager Instance = null;

    [SerializeField]
    GameObject[] Star;

    private void Awake()
    {
        var starlamp = GameObject.FindGameObjectWithTag("starlamp");
        StarCount = starlamp.transform.childCount / 3;

        if (Instance == null)
        {
            Instance = this;
            GetStar = new bool[StarCount, 3];

            Star = new GameObject[StarCount * 3];
            for (int i = 0; i < StarCount * 3; i++)
            {
                Star[i] = GameObject.Find("MoveCanvas/BackGround/Star/" + i);
            }
        }
    }

    private void Update()
    {
        StarLamp();
        for (int i = 0; i < StarCount; i++)
        {
            if (Save.Instance.OnStarLoad(i + 1) == 0)
            {
                GetStar[i, 0] = false;
                GetStar[i, 1] = false;
                GetStar[i, 2] = false;
            }
            if (Save.Instance.OnStarLoad(i + 1) == 1)
            {
                GetStar[i, 0] = true;
                GetStar[i, 1] = false;
                GetStar[i, 2] = false;
            }
            if (Save.Instance.OnStarLoad(i + 1) == 2)
            {
                GetStar[i, 0] = true;
                GetStar[i, 1] = true;
                GetStar[i, 2] = false;
            }
            if (Save.Instance.OnStarLoad(i + 1) == 3)
            {
                GetStar[i, 0] = true;
                GetStar[i, 1] = false;
                GetStar[i, 2] = true;
            }
            if (Save.Instance.OnStarLoad(i + 1) == 4)
            {
                GetStar[i, 0] = true;
                GetStar[i, 1] = true;
                GetStar[i, 2] = true;
            }
        }
    }

    void StarLamp()
    {
        int n = 0;
        for (int i = 0; i < GetStar.GetLength(0); i++)
        {
            for (int j = 0; j < GetStar.GetLength(1); j++)
            {
                if (GetStar[i, j] == true)
                {
                    Star[n].GetComponent<Image>().sprite = OnLamp;
                }
                n++;
            }
        }
    }
}