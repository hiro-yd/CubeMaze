using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    AudioMixer mixer;

    [SerializeField]
    Slider Masterslider;
    [SerializeField]
    Slider Bgmslider;
    [SerializeField]
    Slider Seslider;

    public static float MasterVol;
    public static float BgmVol;
    public static float SeVol;

    private void Start()
    {
        if (Masterslider != null)
            Masterslider.value = MasterVol;
        if (Bgmslider != null)
            Bgmslider.value = BgmVol;
        if (Seslider != null)
            Seslider.value = SeVol;
    }

    public void Master(Slider slider)
    {
        MasterVol = slider.value;
        mixer.SetFloat("Master", slider.value);
    }

    public void BGM(Slider slider)
    {
        BgmVol = slider.value;
        mixer.SetFloat("BGM", slider.value);
    }

    public void SE(Slider slider)
    {
        SeVol = slider.value;
        mixer.SetFloat("SE", slider.value);
    }
}