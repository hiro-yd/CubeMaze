using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            PlayerPrefs.DeleteAll();
    }*/

    #region StarSave
    //星の数セーブしたよ
    public void OnStarSave(bool[] star)
    {
        if (star[0] == false && star[1] == false && star[2] == false)//☆☆☆
        {
            PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 0);
        }
        else if (star[0] == true && star[1] == false && star[2] == false)//★☆☆
        {
            if (OnStarLoad(StageNumber.Stagenumber) != 1 && OnStarLoad(StageNumber.Stagenumber) != 0)
                return;

            else if (OnStarLoad(StageNumber.Stagenumber) == 4)
                return;
            PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 1);
        }

        else if (star[0] == true && star[1] == true && star[2] == false)//★★☆
        {
            if (OnStarLoad(StageNumber.Stagenumber) == 3)
            {
                PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 4);
                return;
            }
            else if (OnStarLoad(StageNumber.Stagenumber) == 4)
                return;
            PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 2);
        }

        else if (star[0] == true && star[1] == false && star[2] == true)//★☆★
        {
            if (OnStarLoad(StageNumber.Stagenumber) == 2)
            {
                PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 4);
                return;
            }
            else if (OnStarLoad(StageNumber.Stagenumber) == 4)
                return;
            PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 3);
        }

        else if (star[0] == true && star[1] == true && star[2] == true)//★★★
            PlayerPrefs.SetInt("Stage" + StageNumber.Stagenumber, 4);
    }

    public int OnStarLoad(int i)
    {
        return PlayerPrefs.GetInt("Stage" + i);
    }
    #endregion

    #region Clear
    //clearデータセーブしたよ
    public void OnClearSave()
    {
        PlayerPrefs.SetInt("Clear" + StageNumber.Stagenumber, 1);
        if (StageNumber.Stagenumber == 3)
        {
            PlayerPrefs.SetInt("Clear6", 1);
        }
    }
    public int OnClearLoad(int i)
    {
        return PlayerPrefs.GetInt("Clear" + i);
    }
    #endregion

    #region Line
    //線の有り無しをセーブしたよ
    public void OnLineSave()
    {
        PlayerPrefs.SetInt("Line" + StageNumber.Stagenumber, 1);
        if (StageNumber.Stagenumber == 3)
        {
            PlayerPrefs.SetInt("Line6", 1);
        }
        if (StageNumber.Stagenumber == 6)
        {
            PlayerPrefs.SetInt("Line9", 1);
        }
    }

    public int OnLineLoad(int i)
    {
        return PlayerPrefs.GetInt("Line" + i);
    }
    #endregion
}