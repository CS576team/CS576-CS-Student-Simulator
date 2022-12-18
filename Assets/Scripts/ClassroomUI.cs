using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassroomUI : MonoBehaviour
{
    public TextMeshProUGUI attempts_text;
    
    internal void UpdateUI(int attempts_num)
    {
        attempts_text.text = "Attempts: " + attempts_num;
    }
}
