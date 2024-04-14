using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string key;
    private Slider slider;
    void Start() {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(key, 1f);
    }
    public void SetLevel() {
        float sliderValue = slider.value;
	    mixer.SetFloat(key, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(key, sliderValue);
    }
}
