using UnityEngine;
using UnityEngine.Events;



public class PlayerLeveling {
    public UnityEvent OnLevelUp;
 
    float exp = 0;

    void FixedUpdate() {
        AddExp(Time.deltaTime);
    }

    // level should be calculated based on exp
    int level { 
        get { return level; } 
        set {
            level = value;
            OnLevelUp.Invoke();
        } 
    }

    // leveling curve defined here
    private int expToNextLevel() {
        return 200 * level^2;
    }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToNextLevel() < exp) {
            level++;
        }
    }
}