using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ModalControl : MonoBehaviour
{
    public List<BoxCollider2D> closeButtons;

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseModal(gameObject);
        }

        //foreach (BoxCollider2D button in closeButtons)
        //{
        //    if(button.)
        //}
    }

    public void OpenModal(GameObject modal)
    {
        modal.SetActive(true);
    }

    public void CloseModal(GameObject modal)
    {
        Console.WriteLine("Closing modal");
        modal.SetActive(false);
    }
}
