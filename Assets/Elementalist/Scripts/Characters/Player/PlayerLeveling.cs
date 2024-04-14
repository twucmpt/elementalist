using UnityEngine;
using UnityEngine.Events;



public class PlayerLeveling : MonoBehaviour {
    public UnityEvent OnLevelUp;
 
    float exp = 0;

    void Update() {
        AddExp(Time.deltaTime);
    }

    private int level = 1;
    // level should be calculated based on exp
    int Level { 
        get { return level; } 
        set {
            level = value;
            exp = 0;
            OnLevelUp.Invoke();
        } 
    }

    // leveling curve defined here
    private int expToLevel() {
        return Level * Level / 2;
    }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToLevel() < this.exp) {
            Level++;
        }
    }

    // i know it says percent but it's actually in the range [0-1]
    public float PercentToNextLevel() {
        return exp / expToLevel();
    }
}