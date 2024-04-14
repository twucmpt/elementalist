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

    //void Update() {
    //    AddExp(Time.deltaTime);
    //}

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
            return 90 * Level * Level;
        }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToLevel() < this.exp) {
            Level++;
        }
        score += (int)exp;
    }

    // i know it says percent but it's actually in the range [0-1]
    public float PercentToNextLevel() {
        return exp / expToLevel();
    }
}