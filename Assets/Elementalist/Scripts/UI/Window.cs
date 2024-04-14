using System;
using TMPro;
using UnityEngine;

public class Window : MonoBehaviour
{
    TMP_Dropdown dropdown;
    void Start() {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = dropdown.options.FindIndex(option => option.text == PlayerPrefs.GetString("Window", "Borderless Fullscreen"));
    }
    public void UpdateWindow() {
        string[] res = PlayerPrefs.GetString("Resolution", "1920x1080").Split('x');
        Enum.TryParse(dropdown.options[dropdown.value].text, out FullScreenMode fullScreenMode);
        Screen.SetResolution(Convert.ToInt32(res[0]), Convert.ToInt32(res[1]), fullScreenMode);
        PlayerPrefs.SetString("Window", dropdown.options[dropdown.value].text);
    }
}
