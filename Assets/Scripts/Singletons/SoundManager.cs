using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static SoundManager I;

    private void Awake()
    {
        I = this;

        audioSource = GetComponent<AudioSource>();
        SetVolume(PlayerPrefs.GetFloat(SettingsMenu.SoundVolumeKey, 1f));
    }

    public void Play(AudioClip sound)
    {
        if (sound) audioSource.PlayOneShot(sound);
    }

    public void StopAll()
    {
        audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
