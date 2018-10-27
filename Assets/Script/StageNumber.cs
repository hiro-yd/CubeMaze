using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNumber : MonoBehaviour
{

    [SerializeField]
    private int StageNum;
    public static int Stagenumber;

    string name = null;

    public void Game()
    {
        FadeTitle.isFadeTitle = false;
        FadeManager.isFadeIn = true;
        Stagenumber = StageNum;
        name = "Stage" + StageNum;
        Invoke("Delay", 1.0f);
    }
    void Delay()
    {
        SceneManager.LoadScene(name);
    }
}