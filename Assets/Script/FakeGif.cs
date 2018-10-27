using UnityEngine;
using UnityEngine.UI;

public class FakeGif : MonoBehaviour
{

    [SerializeField]
    Sprite[] Image;

    int NowImage;

    float time;
    [SerializeField]
    float SetTime;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= SetTime)
        {
            NowImage++;
            time = 0;
        }
        if (NowImage >= Image.Length)
            NowImage = 0;
        for (int i = 0; i < Image.Length; i++)
        {
            if (NowImage == i)
                GetComponent<Image>().sprite = Image[i];
        }
    }
}
