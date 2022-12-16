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
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void panelSwitch(){
        Debug.Log(dd.value);
        if(dd.value == 0){
            defaultPanel.SetActive(true);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(false);
        } else if (dd.value == 1){
            defaultPanel.SetActive(false);
            grade.SetActive(true);
            requirement.SetActive(false);
            review.SetActive(false);
        } else if (dd.value == 2){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(true);
            review.SetActive(false);
        } else if (dd.value == 3){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(true);
        }
    }
}
