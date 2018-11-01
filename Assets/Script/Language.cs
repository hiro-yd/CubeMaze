using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{

    Text text;

    public static int isLanguage;
    /*
     * 0 : 日本語
     * 
     * 1 : 英語
     * 
     * 
    */

    [SerializeField]
    Font us;
    [SerializeField]
    Font jp;

    [SerializeField, Multiline]
    string JpText;
    [SerializeField]
    int JpFontSize;

    [SerializeField, Multiline]
    string UsText;
    [SerializeField]
    int UsFontSize;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (isLanguage == 0)
        {
            Jp();
        }
        if (isLanguage == 1)
        {
            Us();
        }
    }

    public void Us()
    {
        text.font = us;
        text.fontSize = UsFontSize;
        text.text = UsText;
    }

    public void Jp()
    {
        text.font = jp;
        text.fontSize = JpFontSize;
        text.text = JpText;
    }
}