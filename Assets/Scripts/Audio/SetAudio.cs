using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetAudio : MonoBehaviour
{
    public string music;
    public string ambient;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().music = music;
        FindObjectOfType<AudioManager>().ambient = ambient;
    }
}
