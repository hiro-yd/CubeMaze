using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
        text.font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/Us.ttf");
        text.fontSize = UsFontSize;
        text.text = UsText;
    }

    public void Jp()
    {
        text.font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Font/Jp.ttf");
        text.fontSize = JpFontSize;
        text.text = JpText;
    }
}