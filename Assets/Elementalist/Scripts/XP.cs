using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XP : MonoBehaviour
{
    public UnityEvent OnXPGather;
    private float _xp;
    public float radius;
    public float magnetSpeed;
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

    void FixedUpdate() {
        if (Vector3.Distance(GameManager.instance.player.transform.position, transform.position) < radius) {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, Time.fixedDeltaTime * magnetSpeed);
        }
    }
}
