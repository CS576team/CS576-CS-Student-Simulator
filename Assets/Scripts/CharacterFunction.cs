using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterFunction : MonoBehaviour
{

    public GameObject yes;
    public GameObject no;
    public string msg;
    public TMP_Text confirm_text;
    
    public int day;
    public TMP_Text day_text;

    public void LoadData(){
        playerData data = SaveData.Load();
        day = data.day;
        day_text.text = "Day: " + day;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(day == 0){
            LoadData();
        } else if (day == 6){
            SceneManager.LoadScene("SemesterResult");
        }
        
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "OfficeChair"){
            msg = "Computer";
            confirm_text.text = "Start Studying";
            yes.SetActive(true);
            no.SetActive(true);
        }
        else if (other.gameObject.name == "Door"){
            msg = "Classroom";
            if(day != 0 && day % 3 == 0){
                msg = "ExamRoom";
            }
            confirm_text.text = "Leave Dorm";
            yes.SetActive(true);
            no.SetActive(true);
        }
    }
    
}
