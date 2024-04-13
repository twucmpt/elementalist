using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerClickHandler
{
  public UnityEvent buttonClicked;

  public void OnPointerClick(PointerEventData eventData)
  {
    buttonClicked.Invoke();
  }
}