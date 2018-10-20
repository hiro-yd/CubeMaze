using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("動いた音を入れる")]
    AudioClip movesound;
    [SerializeField, Tooltip("星を獲得した時の音を入れる")]
    AudioClip starsound;
    [SerializeField, Tooltip("泥の音を入れる")]
    AudioClip mudsound;
    [SerializeField, Tooltip("水の音を入れる")]
    AudioClip watersound;

    public static int moveCount;

    AudioSource audiosource;

    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸
    float cubeAngle = 0f;                //回転角度

    float cubeSizeHalf;                  //キューブの大きさの半分
    bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    public static PlayerController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        moveCount = 0;
        cubeSizeHalf = transform.localScale.x / 2f;
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (StarObject.StarSound == true) audiosource.PlayOneShot(starsound); StarObject.StarSound = false;

        //回転中は入力を受け付けない
        if (isRotate)
            return;

        #region Input
        if ((Input.GetKeyDown(KeyCode.D) && MoveJudge.rightjudge == false) || (Input.GetKeyDown(KeyCode.RightArrow)&&MoveJudge.rightjudge == false))
        {
            rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, -1);
            moveCount++;
        }

        if ((Input.GetKeyDown(KeyCode.A) && MoveJudge.leftjudge == false) || (Input.GetKeyDown(KeyCode.LeftArrow) && MoveJudge.leftjudge == false))
        {
            rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, 1);
            moveCount++;
        }

        if ((Input.GetKeyDown(KeyCode.W) && MoveJudge.upjudge == false) || (Input.GetKeyDown(KeyCode.UpArrow)&&MoveJudge.upjudge == false))
        {
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
            rotateAxis = new Vector3(1, 0, 0);
            moveCount++;
        }

        if ((Input.GetKeyDown(KeyCode.S) && MoveJudge.downjudge == false) || (Input.GetKeyDown(KeyCode.DownArrow) && MoveJudge.downjudge == false))
        {
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
            rotateAxis = new Vector3(-1, 0, 0);
            moveCount++;
        }
        #endregion

        // 入力がない時はコルーチンを呼び出さないようにする
        if (rotatePoint == Vector3.zero)
            return;
        StartCoroutine(MoveCube());
    }

    IEnumerator MoveCube()
    {
        //回転中のフラグを立てる
        isRotate = true;

        //回転処理
        float sumAngle = 0f; //angleの合計を保存
        while (sumAngle < 90f)
        {
            cubeAngle = 15;
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 90f)
            {
                cubeAngle -= sumAngle - 90f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

            yield return null;
        }
        if (Mud.IsMud == true)
        {
            audiosource.PlayOneShot(mudsound);
            Mud.IsMud = false;
        }
        else if(Water.isWater == true)
        {
            audiosource.PlayOneShot(watersound);
            Water.isWater = false;
        }
        else
        {
            audiosource.PlayOneShot(movesound);
        }
        //回転中のフラグを倒す
        isRotate = false;
        rotatePoint = Vector3.zero;
        rotateAxis = Vector3.zero;

        yield break;
    }
}