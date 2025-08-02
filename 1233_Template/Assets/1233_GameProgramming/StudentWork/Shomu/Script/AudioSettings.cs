using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider audioSlider;

    private const string AUDIO_VOLUME_KEY = "AUDIO_VOLUME";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(AUDIO_VOLUME_KEY, 0.5f);

        audioSource.volume = savedVolume;
        audioSlider.value = audioSource.volume;

        audioSlider.onValueChanged.AddListener((value) =>
        {
            audioSource.volume = value;
            PlayerPrefs.SetFloat(AUDIO_VOLUME_KEY, value);
            PlayerPrefs.Save();
        });
    }
}