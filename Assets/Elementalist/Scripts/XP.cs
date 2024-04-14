using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XP : MonoBehaviour
{
    public UnityEvent OnXPGather;
    private float _xp;
    public float xp {
        get { return _xp; }
        set {
            transform.localScale *= value * scalefactor;
            _xp = value;
        }
    }
    public float scalefactor;

    void OnTriggerEnter2D(Collider2D collider) {
        AddXP(collider);
    }

    void OnTriggerStay2D(Collider2D collider) {
        AddXP(collider);
    }

    void AddXP(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            GameManager.instance.player.GetComponent<PlayerLeveling>().AddExp(xp);
            OnXPGather.Invoke();
            Destroy(gameObject);
        }
    }
}
