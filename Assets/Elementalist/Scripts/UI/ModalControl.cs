using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ModalControl : MonoBehaviour
{

    public void Awake()
    {
        //gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseModal();
        }
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    OpenModal();
        //}
    }

    public void OpenModal()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        
    }

    public void CloseModal()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
