using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;

    float time;
    float alfa;

    [SerializeField, Tooltip("fade用のPanelを入れる")]
    Image FadePanel;

    void Start()
    {
        alfa = 1.0f;
        isFadeOut = true;
    }

    void Update()
    {
        if (isFadeIn)
            FadeIn();

        if (isFadeOut)
            FadeOut();
    }

    void FadeIn()
    {

        FadePanel.gameObject.SetActive(true);
        time += Time.deltaTime / 20;
        alfa += time;
        if (alfa > 1.0f)
        {
            time = 0;
            alfa = 1;
            isFadeIn = false;
        }
        FadePanel.GetComponent<Image>().color = new Color(0, 0, 0, alfa);
    }

    void FadeOut()
    {
        time -= Time.deltaTime / 20;
        alfa += time;
        if (alfa < 0.0f)
        {
            time = 0;
            alfa = 0;
            isFadeOut = false;
            FadePanel.gameObject.SetActive(false);
        }
        FadePanel.GetComponent<Image>().color = new Color(0, 0, 0, alfa);
    }
}