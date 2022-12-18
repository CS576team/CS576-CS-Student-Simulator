using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CharacterFunction : MonoBehaviour
{

    public GameObject yes;
    public GameObject no;
    public string msg;
    public TMP_Text confirm_text;
    
    public int day;
    public TMP_Text day_text;

    public int diff;
    public TMP_Text diff_text;
    
    public bool isPF;

    public void LoadData(){
        playerData data = SaveData.Load();
        day = data.day;
        diff = data.diff;
        isPF = data.isPF;
        
        diff_text.text = "Diff: " +diff;
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
        if(day == 0){ // everytime going back to the dorm we load the day data again.
            LoadData();
        } else if (day == 6 ){
            string path = "Assets/Scripts/Data/player.fun";
            File.Delete (path);

            SceneManager.LoadScene("SemesterRsult");
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
