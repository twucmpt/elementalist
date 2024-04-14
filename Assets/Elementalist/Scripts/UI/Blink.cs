using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// this toggles a component (usually an Image or Renderer) on and off for an interval to simulate a blinking effect
public class Blink : MonoBehaviour {

	// this is the UI.Text or other UI element you want to toggle
	public GameObject imageToToggle;

	public float interval = 1f;
	public float startDelay = 0.5f;
	public static IEnumerator ToggleStateRoutine(GameObject toggledObject, float startDelay, float interval)
	{
		yield return new WaitForSeconds(startDelay);
    while (true)
    {
      ToggleState(toggledObject);
      yield return new WaitForSeconds(interval);
    }
	}
	
  private static void ToggleState(GameObject imageToToggle) 	{
		imageToToggle.SetActive(!imageToToggle.activeSelf);
	}
}