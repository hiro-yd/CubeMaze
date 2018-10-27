using UnityEngine;

public class BackGroundManager : MonoBehaviour
{

    #region GameObject
    public GameObject ObjA;
    public GameObject ObjB;
    public GameObject ObjC;

    public GameObject ObjStart;
    #endregion

    float RandomPosA;
    float RandomPosB;
    float RandomPosC;

    float timeA = 0;
    float timeB = 0;
    float timeC = 0;

    void Update()
    {
        RandomPosA = Random.Range(-8.0f, 40.0f);
        RandomPosB = Random.Range(-8.0f, 140.0f);
        RandomPosC = Random.Range(-8.0f, 40.0f);
        if (PauseManager.BackGround == false && GoalManager.goal == false)
        {
            timeA += Time.deltaTime;
            timeB += Time.deltaTime;
            timeC += Time.deltaTime;
        }
        if (timeA >= 0.5f)
        {
            Instantiate(ObjA, new Vector3(ObjStart.transform.position.x, ObjStart.transform.position.y, ObjStart.transform.position.z + RandomPosA), Quaternion.identity);
            timeA = 0;
        }
        if (timeB >= 4.5f)
        {
            Instantiate(ObjB, new Vector3(ObjStart.transform.position.x - 180, ObjStart.transform.position.y - 100, ObjStart.transform.position.z + RandomPosB), Quaternion.identity);
            timeB = 0;
        }
        if (timeC >= 0.5f)
        {
            Instantiate(ObjC, new Vector3(ObjStart.transform.position.x, ObjStart.transform.position.y, ObjStart.transform.position.z + RandomPosA), Quaternion.identity);
            timeC = 0;
        }
    }
}