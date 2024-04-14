using System;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalManager : MonoBehaviour
{
    public AudioMixer mixer;
    void Awake() {
        LoadAudioSettings();
        LoadGraphicalSettings();
    }

    void LoadAudioSettings() {
        LoadAudioSetting("MasterVolume");
        LoadAudioSetting("MusicVolume");
        LoadAudioSetting("SFXVolume");
    }

    void LoadGraphicalSettings() {
        string[] res = PlayerPrefs.GetString("Resolution", "1920x1080").Split('x');
        Enum.TryParse(PlayerPrefs.GetString("Window", "Borderless Fullscreen"), out FullScreenMode fullScreenMode);
        Screen.SetResolution(Convert.ToInt32(res[0]), Convert.ToInt32(res[1]), fullScreenMode);
    }

    void LoadAudioSetting(string key) {
        mixer.SetFloat(key, Mathf.Log10(PlayerPrefs.GetFloat(key, 1f)) * 20);
    }
}
