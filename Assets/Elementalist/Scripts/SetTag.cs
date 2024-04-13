using System;
using UnityEngine;

public class SetTag : MonoBehaviour
{
    public void Set(String tag) {
        gameObject.tag = tag;
    }

    public void Remove() {
        gameObject.tag = "Untagged";
    }
}
