using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f,360));
        for (int i = 0; i < transform.childCount; i++) {
            for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                transform.GetChild(i).GetChild(j).eulerAngles=new Vector3(0,0,0);
            }
        }
    }

}
