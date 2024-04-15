using UnityEngine;
using UnityEngine.Events;

public class PlayerLeveling : MonoBehaviour {
    public UnityEvent OnLevelUp;
 
    float exp = 0;

    int startingExp;

    void Awake() {
        // start with 1 level
        startingExp = expToLevel() + 1;
        AddExp(startingExp);
    }

    private int levelScalingConstant = 60;
    public int LevelScalingConstant { get; set; }

    public int LevelScalingOffset { get; set; }

    private int level = 0;
    // level should be calculated based on exp
    public int Level { 
        get { return level; } 
        set {
            level = value;
            exp = 0;
            OnLevelUp.Invoke();
        } 
    }
    
    private int score = 0;
    public int Score { get { return score - startingExp; } }

    // leveling curve defined here
    private int expToLevel() {
        return LevelScalingConstant * Level * Level + LevelScalingOffset;
    }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToLevel() < this.exp) {
            Level++;
        }
        score += (int)(exp * GameManager.instance.GetDifficultySetting().scoreMultiplier);
    }

    // i know it says percent but it's actually in the range [0-1]
    public float PercentToNextLevel() {
        return exp / expToLevel();
    }
}