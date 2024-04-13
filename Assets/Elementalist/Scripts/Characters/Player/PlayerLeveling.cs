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
            OnLevelUp.Invoke();
        } 
    }

    // leveling curve defined here
    private int expToNextLevel() {
        return 10 * Level * Level;
    }

    public void AddExp(float exp) {
        this.exp += exp;
        if(expToNextLevel() < this.exp) {
            Level++;
        }
    }
}