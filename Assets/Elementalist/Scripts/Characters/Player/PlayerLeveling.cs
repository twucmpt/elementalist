using UnityEngine;
using UnityEngine.Events;

public class PlayerLeveling : MonoBehaviour {
    public UnityEvent OnLevelUp;
 
    float exp = 0;

    void Awake() {
        Debug.Log("PlayerLeveling awake");

        // start with 1 level
        AddExp(expToLevel() + 1);
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

    // leveling curve defined here
    private int expToLevel() {
        return 150 * Level + 1 * Level + 1;
    }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToLevel() < this.exp) {
            Level++;
        }
    }

    public int GetScore() {
        return (int)exp;
    }

    // i know it says percent but it's actually in the range [0-1]
    public float PercentToNextLevel() {
        return exp / expToLevel();
    }
}