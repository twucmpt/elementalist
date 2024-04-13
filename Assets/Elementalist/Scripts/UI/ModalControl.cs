using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ModalControl : MonoBehaviour
{

    public void Awake()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseModal();
        }
    }

    public void OpenModal()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        
    }

    public virtual void CloseModal()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
