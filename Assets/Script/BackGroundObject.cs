using UnityEngine;

public class BackGroundObject : MonoBehaviour
{

    enum Type
    {
        Rotate,
        Stay
    }

    [SerializeField]
    Type type;

    [SerializeField,Tooltip("オブジェクトが消える場所")]
    private GameObject EndObj;

    float speed;
    float RandomX;
    float RandomY;
    float RandomZ;

    private void Start()
    {
        EndObj = GameObject.Find("ObjEnd");
        speed = Random.Range(0.01f, 2.0f);
    }

    void Update()
    {
        if (PauseManager.BackGround == false && GoalManager.goal == false)
        {
            if (type == Type.Rotate)
            {
                RandomX = Random.Range(0f, 5f);
                RandomY = Random.Range(0f, 5f);
                RandomZ = Random.Range(0f, 5f);
                transform.Rotate(new Vector3(RandomX, RandomY, RandomZ));
            }
            transform.position += new Vector3(speed, 0, 0);
        }
        if (transform.position.x >= EndObj.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

}