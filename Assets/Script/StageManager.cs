using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour{

    int StageCount;

    [SerializeField]
    GameObject[] Stage;
    
    public bool[] UnLockStage;

    public static StageManager Instance;

    void Awake()
    {
        var StageNum = GameObject.FindGameObjectWithTag("stage");
        StageCount = StageNum.transform.childCount;
        if (Instance == null)
        {
            Instance = this;
            UnLockStage = new bool[StageCount];

            Stage = new GameObject[StageCount];
            for (int i = 0; i < StageCount; i++)
            {
                Stage[i] = GameObject.Find("MoveCanvas/BackGround/Stage/" + i);
                Stage[i].GetComponent<Button>().enabled = false;
            }
            UnLockStage[0] = true;
        }
    }

    void Update()
    {
        StageUnLock();
        for (int i = 1; i < StageCount; i++)
        {
            if(Save.Instance.OnClearLoad(i) == 1)
            {
                UnLockStage[i] = true;
            }
            else if (Save.Instance.OnClearLoad(i) == 0)
            {
                UnLockStage[i] = false;
            }
            if (Save.Instance.OnClearLoad(6) == 1 && Save.Instance.OnClearLoad(9) == 1)
            {
                UnLockStage[9] = true;
            }
        }
    }
    void StageUnLock()
    {
        int n = 0;
        for (int i = 0; i < UnLockStage.Length; i++)
        {
            {
                if (UnLockStage[i] == true)
                {
                    Stage[n].GetComponent<Button>().enabled = true;
                }
                n++;
            }
        }
    }
}