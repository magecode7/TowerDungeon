using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public const string MusicVolumeKey = "MusicVolume";
    public const string SoundVolumeKey = "SoundVolume";

    [SerializeField] private Slider musicSlider, soundSlider;

    private void Awake()
    {
        musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(MusicVolumeKey, 1f));
        soundSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(SoundVolumeKey, 1f));
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        MusicManager.I.SetVolume(volume);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        
        SoundManager.I.SetVolume(volume);
        PlayerPrefs.SetFloat(SoundVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
