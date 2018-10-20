using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {

    [SerializeField]
    private ColorJudge Cm;
    private GameObject Player;
    private GameObject GoalEffect;
    private GameObject GoalPanel;
    private GameObject Starcheck;

    public static bool goal = false;

    void Start()
    {
        Starcheck = GameObject.Find("StarCheck");
        GoalEffect = GameObject.Find("GoalEffect");
        Player = GameObject.Find("Player_Cube");
        GoalPanel = GameObject.Find("Canvas/GoalPanel");
        GoalEffect.SetActive(false);
        GoalPanel.SetActive(false);
        PlayerController.moveCount = 0;
    }

    void Update()
    {
        if (Cm.judge)
        {
            GoalPanel.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            goal = true;
            Starcheck.GetComponent<StarCheck>().StarJudge();
            GoalEffect.SetActive(true);
            StageManager.Instance.UnLockStage[StageNumber.Stagenumber] = true;
            Save.Instance.OnStarSave(StarCheck.Instance.star);
            Save.Instance.OnClearSave();
            Save.Instance.OnLineSave();
            Cm.judge = false;
        }
        if (goal)
        {
            Player.transform.position += new Vector3(0f, -1f, 0f);
        }
    }
}