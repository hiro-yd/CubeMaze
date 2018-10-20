using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickManager : MonoBehaviour
{

    GameObject PauseManager;
    GameObject OptionPanel;

    GameObject TitlePanel;
    GameObject ClickToStart;
    GameObject ClickText;
    GameObject HowToPlayMenu;

    bool isOption = false;
    bool isHowTo = false;

    string name = null;

    private void Start()
    {
        ClickText = GameObject.Find("Canvas/ClickText");
        HowToPlayMenu = GameObject.Find("Canvas/HowToPlayMenu");
        ClickToStart = GameObject.Find("Canvas/MainMenuButton");
        TitlePanel = GameObject.Find("Canvas/TitlePanel");
        PauseManager = GameObject.Find("PauseManager");
        OptionPanel = GameObject.Find("StayCanvas/OptionPanel");
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
    }

    public void Japanese()
    {
        Language.isLanguage = 0;
    }

    public void English()
    {
        Language.isLanguage = 1;
    }

    public void MainMenu()
    {
        ClickToStart.SetActive(false);
        ClickText.SetActive(false);
        TitlePanel.SetActive(true);
    }

    public void HowToPlay()
    {
        isHowTo = !isHowTo;
        if (isHowTo)
            HowToPlayMenu.SetActive(true);
        if (!isHowTo)
            HowToPlayMenu.SetActive(false);
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }

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
}
