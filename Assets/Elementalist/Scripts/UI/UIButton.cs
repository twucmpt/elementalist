using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerClickHandler
{
  public UnityEvent buttonClicked;

  public virtual void OnPointerClick(PointerEventData eventData)
  {
    buttonClicked.Invoke();
  }
}