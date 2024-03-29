using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float soundEffectVolume { get; private set; }
    [SerializeField] private Text musicSliderText;
    [SerializeField] private Text soundEffectsSliderText;
    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        musicSliderText.text = ((int)(value*100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }
    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectVolume = value;
        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }
}
