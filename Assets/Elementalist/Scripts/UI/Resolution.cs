using System;
using TMPro;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    TMP_Dropdown dropdown;
    void Start() {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = dropdown.options.FindIndex(option => option.text == PlayerPrefs.GetString("Resolution", "1920x1080"));
    }
    public void UpdateResolution() {
        string[] res = dropdown.options[dropdown.value].text.Split('x');
        Enum.TryParse(PlayerPrefs.GetString("Window", "Borderless Fullscreen"), out FullScreenMode fullScreenMode);
        Screen.SetResolution(Convert.ToInt32(res[0]), Convert.ToInt32(res[1]), fullScreenMode);
        PlayerPrefs.SetString("Resolution", dropdown.options[dropdown.value].text);
    }
}
