using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ReviveSkele : MonoBehaviour
{
    public UnityEvent OnReviveAnimation;
    public UnityEvent OnRevive;
    public bool canRevive = true;
    public float delay = 1;
    public float animationDelay = 1;
    
    public void OnDeath() {
        if (canRevive) StartCoroutine(DelayRevive());
    }

    IEnumerator DelayRevive()
    {
        yield return new WaitForSeconds(delay);
        canRevive = false;
        OnReviveAnimation.Invoke();
        yield return new WaitForSeconds(animationDelay);
        OnRevive.Invoke();
    }
}
