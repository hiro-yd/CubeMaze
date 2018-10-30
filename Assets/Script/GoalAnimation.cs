using UnityEngine;

public class GoalAnimation : MonoBehaviour
{
    Animator anim;

    public static GoalAnimation Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    public void Star()
    {
        if (StarCheck.Instance.animstar == 1)
            anim.Play("Star1");
        if (StarCheck.Instance.animstar == 11)
            anim.Play("Star11");
        if (StarCheck.Instance.animstar == 101)
            anim.Play("Star101");
        if (StarCheck.Instance.animstar == 111)
            anim.Play("Star111");
    }
}
