using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class SceneSwitch : MonoBehaviour
{

    public string input;
    public GameObject yes;
    public GameObject no;
    public CharacterFunction cf;
    public TMP_Text day_text;
    public int day;

    public TMP_Text PF_text;
    public bool isPF;
    public bool isRead;

    public int diff;//goal grade
    public Slider slider;
    public TMP_Text diff_text;

    public int grade;
    public GameObject directionPanel;


    public void savePlayerData(){
        SaveData.SavePlayer(this);
    }
    public int LoadDayData(){
        playerData data = SaveData.Load();
        return data.day; 
    }
    public int LoadGradeData(){
        playerData data = SaveData.Load();
        return data.grade; 
    }
    public void saveGrade(){
        grade = PlayerPrefs.GetInt("grade");
        Debug.Log("Saving grade from classroom: " + grade);
        savePlayerData();
    }
    public void LoadPlayerData(){
        playerData data = SaveData.Load();
        day = data.day;
        diff = data.diff;
        isPF = data.isPF;
        grade = data.grade;
        isRead = data.isRead;
    }
    
    void Start(){
        LoadPlayerData();
        Debug.Log("data checking from sceneSwitch: day: "+ day+ " grade: "+ grade + " diff: "+ diff);
    }
    public void noDirection(){
        isRead = true;
        directionPanel.SetActive(false);
        savePlayerData();
    }

    
    public void switchScene(string scenename)
    {
        Debug.Log(scenename);
        if (scenename == "Computer"){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else if(scenename == "Menu"){
            string path = "Assets/Scripts/Data/player.fun";
            File.Delete (path);
        }

        SceneManager.LoadScene(scenename);
    }

    public void readInput(string i){
        input = i;
        Debug.Log(input);
        if (input == "Start" || input == "start"){
            savePlayerData();
            SceneManager.LoadScene("Dorm");
        }
        if (input == "Tips" || input == "tips"){
            savePlayerData();
            SceneManager.LoadScene("Tips");
        }
    }

    public void pfConfirm(){
        LoadPlayerData();
        if (day <=3 && isPF == false){
            isPF = true;
            diff = 59;
            PF_text.text = "You have chosen P/F as your passing garde.";
        } else if (day > 3){
            string letter = "";
            if (diff== 70){
                letter = "C";
            }  else if (diff == 80){
                letter = "B";
            } else if (diff == 90){
                letter = "A";
            } else if (diff == 60){
                letter = "D";
            }else {
                letter = "P/F";
            }
            PF_text.text = "You have passed the P/F deadline. You have chosen "+ letter+ " as your passing garde.";
        }
        
        savePlayerData();
    }

    public void getDifficulty(){
        int val = (int)slider.value;
        if (val>= 70 && val <80){
            diff = 70;
            diff_text.text = "C";
        }  else if (val>= 80 && val <90){
            diff = 80;
            diff_text.text = "B";
        } else if (val>= 90 && val <=100){
            diff = 90;
            diff_text.text = "A";
        } else {
            diff = 60;
            diff_text.text = "D";
        }
        savePlayerData();
        
    }

    public void confirmBox(string msg){
        Debug.Log("confirmbox appeared!");
        if (msg == "yes"){
            Debug.Log("scene:"+cf.msg);
            
            if(cf.msg == "Classroom" || cf.msg == "ExamRoom" ){
                day = LoadDayData() +1;
                grade = LoadGradeData();
                savePlayerData();
            }
            else if(cf.msg == "Computer" ){
                day = LoadDayData();
                savePlayerData();
            }
            SceneManager.LoadScene(cf.msg);
        }
        
        yes.SetActive(false);
        no.SetActive(false); 
    }


}
