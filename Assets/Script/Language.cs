using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
#if UNITY_EDITOR
        text.font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/Us.ttf");
#endif
        text.fontSize = UsFontSize;
        text.text = UsText;
    }

    public void Jp()
    {
#if UNITY_EDITOR
        text.font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/Jp.ttf");
#endif
        text.fontSize = JpFontSize;
        text.text = JpText;
    }
}