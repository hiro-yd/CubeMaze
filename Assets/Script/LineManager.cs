using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour{

    int LineCount;

    [SerializeField]
    GameObject[] line;

    public bool[] ClearLine;

    public static LineManager Instance;

    void Awake()
    {
        var LineNum = GameObject.FindGameObjectWithTag("line");
        LineCount = LineNum.transform.childCount;
        if (Instance == null)
        {
            Instance = this;
            ClearLine = new bool[LineCount];

            line = new GameObject[LineCount];
            for (int i = 0; i < LineCount; i++)
            {
                line[i] = GameObject.Find("MoveCanvas/BackGround/Line/" + i);
                line[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }
        }
    }

    void Update()
    {
        DrawLine();
        for (int i = 0; i < LineCount; i++)
        {
            if (Save.Instance.OnLineLoad(i+1) == 1)
            {
                ClearLine[i] = true;
            }
            else if (Save.Instance.OnLineLoad(i+1) == 0)
            {
                ClearLine[i] = false;
            }
        }
    }

    void DrawLine()
    {
        int n = 0;
        for(int i = 0; i < ClearLine.Length; i++)
        {
            if(ClearLine[i] == true)
            {
                line[n].GetComponent<Image>().color = new Color(0, 0, 0, 255);
            }
            n++;
        }
    }
}