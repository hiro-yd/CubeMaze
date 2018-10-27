using UnityEngine;
using UnityEngine.UI;

public class FadeTitle : MonoBehaviour
{

    [SerializeField, Tooltip("FadeTitleを入れる")]
    GameObject FadeTitlePanel;

    float time = 0.0f;
    float alfa = 0.0f;

    public static bool isFadeTitle = false;

    void Start()
    {

    }

    void Update()
    {
        if (isFadeTitle == true)
            FadeOut();
        if (isFadeTitle == false)
            FadeIn();
    }
    void FadeIn()
    {
        PlayerController.Instance.GetComponent<PlayerController>().enabled = false;
        FadeTitlePanel.SetActive(true);
        time += Time.deltaTime;
        alfa += time;
        if (alfa >= 2.0f)
        {
            time = 0;
            alfa = 2;
            isFadeTitle = true;
        }
        FadeTitlePanel.GetComponent<Image>().color = new Color(0, 0, 0, alfa);
    }

    void FadeOut()
    {

        time -= Time.deltaTime / 60;
        alfa += time;
        if (alfa <= 0.0f)
        {
            time = 0;
            alfa = 0;
            PlayerController.Instance.GetComponent<PlayerController>().enabled = true;
            FadeTitlePanel.SetActive(false);
        }
        FadeTitlePanel.GetComponent<Image>().color = new Color(0, 0, 0, alfa);
    }
}
