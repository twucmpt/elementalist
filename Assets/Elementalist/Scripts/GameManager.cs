using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    void Awake() {
        instance = this;
    }

    public List<DifficultySetting> difficulties;

    public DifficultySetting GetDifficultySetting() {
        return difficulties[PlayerPrefs.GetInt("Difficulty", 0)];
    }

    void Start() {
        OnDifficultyChange();
    }

    public void OnDifficultyChange() {
        DifficultySetting setting = GetDifficultySetting();

        // Player Speed
        player.GetComponent<PlayerMovement>().moveSpeed = setting.playerSpeed;

        // Player Health
        Health health = player.GetComponent<Health>();
        var ratio = health.health / health.maxHealth;
        health.maxHealth = setting.playerHealth;
        health.health = health.maxHealth * ratio;

        //Player Invicibility
        health.invicinbilityCooldown = setting.playerInvicinbility;

        // Player Leveling
         player.GetComponent<PlayerLeveling>().LevelScalingConstant = setting.levelScalingConstant;
    }
}

public enum DamageType {
    Untyped,
    Fire,
    Water,
    Earth,
    Air,
    Lightning,
    Poison,
    Blood,
    Ice,
    Sand
}