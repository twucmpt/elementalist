using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToPage : MonoBehaviour
{
    private GameObject currentPage;

    void Start() {
        currentPage = transform.GetChild(0).gameObject;
    }
    public void OpenPage(GameObject page) {
        currentPage.SetActive(false);
        currentPage = page;
        currentPage.SetActive(true);
    }
}
