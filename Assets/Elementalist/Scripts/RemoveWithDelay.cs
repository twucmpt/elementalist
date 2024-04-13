using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWithDelay : MonoBehaviour
{
    public float delay;
    void Start()
    {
        if (delay > 0) {
            DelayDestroy(delay);
        }
    }
    public void DelayDestroy(float delay) {
        StartCoroutine(_DelayDestroy(delay));
    }
    IEnumerator _DelayDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
