using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Button back_to_dorm;

    void Start() {
        back_to_dorm.onClick.AddListener(ProcessButton);
    }

    void ProcessButton() {
        // Go back to dorm
        Debug.Log("Going back to dorm...");
    }

    public void Setup() {
        gameObject.SetActive(true);
    }
}
