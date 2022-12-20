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
    public int grade;

    public AudioClip open; 
    private AudioSource aS;

    public GameObject directionPanel;

    public void LoadData(){
        playerData data = SaveData.Load();
        day = data.day;
        diff = data.diff;
        isPF = data.isPF;
        grade = data.grade;
       
        diff_text.text = "Diff: " +diff;
        day_text.text = "Day: " + (day+1);
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        aS = gameObject.GetComponent<AudioSource>();
        playerData pd = SaveData.Load();
        Debug.Log("CF check: pd.isRead = "+ pd.isRead);
        if(pd.isRead == false){directionPanel.SetActive(true);} else{directionPanel.SetActive(false);}
        
    }

    // Update is called once per frame
    void Update()
    {
         // everytime going back to the dorm we load the day data again.
        LoadData();
        
        if (day == 7){  
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
            Debug.Log("day checking from CF: "+ day);
            msg = "Classroom";
            if(day != 0 && (day+1) % 3 == 0){
                msg = "ExamRoom";
                if((day+1) == 6){
                    msg = "ExamRoom2";
                }
            }
            confirm_text.text = "Leave Dorm";
            yes.SetActive(true);
            no.SetActive(true);
                            
            aS.clip = open; 
            aS.Play();
        }
    }
    
}
