using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static MusicManager I;

    private void Awake()
    {
        I = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void SetLocationMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Resume()
    {
        audioSource.UnPause();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }
}
