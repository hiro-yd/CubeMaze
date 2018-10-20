using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

    [SerializeField]
    ColorJudge[] Cj;

    int Count;

	void Start ()
    {
        for(int i = 0; i < Cj.Length; i++)
        {
            Cj[i].judge = false;
        }
	}
	
	void Update ()
    {
        for (int i = 0; i < Cj.Length; i++)
        {
            if (Cj[i].judge)
            {

            }
            if (Count == Cj.Length)
            {

            }
        }
	}
}
