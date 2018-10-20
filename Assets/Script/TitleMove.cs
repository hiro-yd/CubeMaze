using System.Collections;
using UnityEngine;

public class TitleMove : MonoBehaviour {
    Vector3 rotatePoint = Vector3.zero;  //回転の中心
    Vector3 rotateAxis = Vector3.zero;   //回転軸

    float cubeAngle = 0f;                //回転角度
    float cubeSizeHalf;                  //キューブの大きさの半分
    float time = 0;

    bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない

    #region mvoe
    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;
    #endregion

    void Start()
    {
        cubeSizeHalf = transform.localScale.x / 2f;
    }

    void Update()
    {
        time += Time.deltaTime;

        #region Auto
        if(time > 0 && time < 0.5f)
        {
            right = true;
        }
        if (time > 0.6f && time < 1.4f)
        {
            up = true;
        }
        if(time > 1.6f && time < 2.3f)
        {
            left = true;
        }
        if(time > 2.4f && time < 2.7f)
        {
            down = true;
        }
        if(time > 2.8f && time < 3.2f)
        {
            right = true;
        }
        if(time >3.3f && time < 3.7f)
        {
            down = true;
        }
        if(time > 3.8f)
        {
            time = 0.3f;
        }
        #endregion

        //回転中は入力を受け付けない
        if (isRotate)
            return;

        if (right == true)
        {
            rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, -1);
            right = false;
        }
        if (left == true)
        {
            rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
            rotateAxis = new Vector3(0, 0, 1);
            left = false;
        }
        if (up == true)
        {
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
            rotateAxis = new Vector3(1, 0, 0);
            up = false;
        }
        if (down == true)
        {
            rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
            rotateAxis = new Vector3(-1, 0, 0);
            down = false;
        }
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
            cubeAngle = 15f; //ここを変えると回転速度が変わる
            sumAngle += cubeAngle;

            // 90度以上回転しないように値を制限
            if (sumAngle > 90f)
            {
                cubeAngle -= sumAngle - 90f;
            }
            transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

            yield return null;
        }
        //回転中のフラグを倒す
        isRotate = false;
        rotatePoint = Vector3.zero;
        rotateAxis = Vector3.zero;

        yield break;
    }
}
