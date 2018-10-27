using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickManager : MonoBehaviour
{

    #region GamaObject

    GameObject PauseManager;
    GameObject OptionPanel;

    GameObject TitlePanel;
    GameObject ClickToStart;
    GameObject ClickText;
    GameObject HowToPlayMenu;
    GameObject NextPageButton;
    GameObject BackPageButton;
    #endregion

    bool isOption = false;
    bool isHowTo = false;

    string name = null;

    private void Start()
    {

        #region Find
        ClickText = GameObject.Find("Canvas/ClickText");
        HowToPlayMenu = GameObject.Find("Canvas/HowToPlay");
        ClickToStart = GameObject.Find("Canvas/MainMenuButton");
        TitlePanel = GameObject.Find("Canvas/TitlePanel");
        PauseManager = GameObject.Find("PauseManager");
        OptionPanel = GameObject.Find("StayCanvas/OptionPanel");
        NextPageButton = GameObject.Find("Canvas/NextPage");
        BackPageButton = GameObject.Find("Canvas/BackPage");
        #endregion

        #region NullCheck
        if (NextPageButton != null)
            NextPageButton.SetActive(false);

        if (BackPageButton != null)
            BackPageButton.SetActive(false);

        if (ClickText != null)
            ClickText.SetActive(true);

        if (HowToPlayMenu != null)
            HowToPlayMenu.SetActive(false);

        if (ClickToStart != null)
            ClickToStart.SetActive(true);

        if (TitlePanel != null)
            TitlePanel.SetActive(false);

        if (OptionPanel != null)
            OptionPanel.SetActive(false);
        #endregion

    }

    #region Language
    public void Japanese()
    {
        Language.isLanguage = 0;
    }

    public void English()
    {
        Language.isLanguage = 1;
    }
    #endregion

    #region Title
    public void MainMenu()
    {
        ClickToStart.SetActive(false);
        ClickText.SetActive(false);
        TitlePanel.SetActive(true);
    }

    public void Howtoplay()
    {
        isHowTo = !isHowTo;
        if (isHowTo)
        {
            HowToPlayMenu.SetActive(true);
            NextPageButton.SetActive(true);
            BackPageButton.SetActive(true);
        }

        else if (!isHowTo)
        {
            HowToPlay.NowPage = 0;
            HowToPlayMenu.SetActive(false);
            NextPageButton.SetActive(false);
            BackPageButton.SetActive(false);
        }
    }

    public void NextPage()
    {
        HowToPlay.NowPage++;
    }

    public void BackPage()
    {
        HowToPlay.NowPage--;
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    #region GameButton
    public void Title()
    {
        FadeManager.isFadeIn = true;
        name = "Title";
        Invoke("Delay", 1.0f);
    }

    public void ReStart()
    {
        PauseManager.GetComponent<PauseManager>().ClosePanel();
    }

    public void Option()
    {
        isOption = !isOption;
        if (isOption)
            OptionPanel.SetActive(true);
        if (!isOption)
            OptionPanel.SetActive(false);
    }

    public void NextStage()
    {
        FadeManager.isFadeIn = true;
        StageNumber.Stagenumber += 1;
        name = "Stage" + StageNumber.Stagenumber;
        Invoke("Delay", 1.0f);
    }

    public void StageSelect()
    {
        FadeManager.isFadeIn = true;
        name = "StageSelect";
        Invoke("Delay", 1.0f);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        FadeManager.isFadeIn = true;
        name = "Stage" + StageNumber.Stagenumber;
        Invoke("Delay", 1.0f);
    }

    void Delay()
    {
        GoalManager.goal = false;
        SceneManager.LoadScene(name);
    }
    #endregion
}
