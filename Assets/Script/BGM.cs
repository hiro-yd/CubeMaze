using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

    AudioClip BGM_A;
    AudioClip BGM_b;
    AudioClip BGM_C;
    AudioClip BGM_D;
    AudioClip BGM_E;
    AudioClip BGM_F;
    AudioClip BGM_G;

    AudioSource audiosource;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        audiosource.PlayOneShot(BGM_A);
	}
}