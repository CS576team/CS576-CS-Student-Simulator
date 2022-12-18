using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public Button back_to_dorm;
    public TextMeshProUGUI grade_text;

    void Start() {
        back_to_dorm.onClick.AddListener(ProcessButton);
    }

    void ProcessButton() {
        // Go back to dorm, Load dorm scene below
        Debug.Log("Going back to dorm...");
    }

    public void Setup() {
        int grade = PlayerPrefs.GetInt("grade");
        grade_text.text = "Current grade: " + grade;
        gameObject.SetActive(true);
    }

}
