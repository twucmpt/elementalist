using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    public UnityEvent OnDifficultyChanged;
    public List<Toggle> options;

    void Start() {
        SetDifficulty(PlayerPrefs.GetInt("Difficulty", 0));
    }

    public void SetEasy(bool val) {
        if (val) SetDifficulty(0);
    }

    public void SetNormal(bool val) {
        if (val) SetDifficulty(1);
    }

    public void SetHard(bool val) {
        if (val) SetDifficulty(2);
    }

    void SetDifficulty(int i) {
        foreach (Toggle option in options) {
            if (options[i] == option) continue;
            option.isOn = false;
            option.interactable = true;
        }
        PlayerPrefs.SetInt("Difficulty", i);
        options[i].interactable = false;
        OnDifficultyChanged.Invoke();
    }
}
