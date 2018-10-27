using UnityEngine;

public class HowToPlay : MonoBehaviour
{

    public static int NowPage;

    int PageCount;

    [SerializeField]
    GameObject[] Page;

    private void Awake()
    {
        var page = GameObject.FindGameObjectWithTag("page");
        PageCount = page.transform.childCount;

        Page = new GameObject[PageCount];
        for (int i = 0; i < PageCount; i++)
        {
            Page[i] = GameObject.Find("Canvas/HowToPlay/" + i);
        }

    }

    void Update()
    {
        if (NowPage >= Page.Length)
            NowPage = Page.Length-1;

        if (NowPage <= -1)
            NowPage = 0;

        for (int i = 0; i < PageCount; i++)
        {
            if (NowPage == i)
                Page[i].SetActive(true);

            else
                Page[i].SetActive(false);
        }
    }
}
