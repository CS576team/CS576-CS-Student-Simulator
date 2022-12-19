using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class screen : MonoBehaviour
{
    public TMP_Dropdown dd;
    public GameObject defaultPanel;
    public GameObject grade;
    public GameObject requirement;
    public GameObject review;
    public GameObject rules;
    public TMP_Text dayzerotext;
    public TMP_Text gradetext;

    public void panelSwitch(){
        Debug.Log(dd.value);
        playerData pd = SaveData.Load();
        if(dd.value == 0){
            defaultPanel.SetActive(true);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(false);
        } else if (dd.value == 1){
            defaultPanel.SetActive(false);
            grade.SetActive(true);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(false);
            gradetext.text = "Your current grade is: " + pd.grade;  
        } else if (dd.value == 2){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(true);
            review.SetActive(false);
            rules.SetActive(false);
        } else if (dd.value == 3){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(true);
            rules.SetActive(false);
            Debug.Log("pd.day = "+ pd.day);
            dayzerotext.text = "";
            if(pd.day == 0){
                dayzerotext.text = "You haven't taken any classes yet!"+"\nPlaese go to class first!";
            }
            
        } else if (dd.value == 4){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(true);
        }
    }
}
