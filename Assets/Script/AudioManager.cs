using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer mixer;

    public void MasterVol(Slider slider)
    {
        mixer.SetFloat("master", slider.value);
    }
}
