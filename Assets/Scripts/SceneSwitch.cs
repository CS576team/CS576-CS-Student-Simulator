using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    public int diff;//goal grade
    public Slider slider;
    public TMP_Text diff_text;

    public int grade;

    public void savePlayerData(){
        SaveData.SavePlayer(this);
    }
    public int LoadDayData(){
        playerData data = SaveData.Load();
        return data.day; 
    }
    public void LoadPlayerData(){
        playerData data = SaveData.Load();
        day = data.day;
        diff = data.diff;
        isPF = data.isPF;
    }
    
    void Start(){
        LoadPlayerData();
    }
    
    public void switchScene(string scenename)
    {
        Debug.Log(scenename);
        if (scenename == "Computer"){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } if(scenename == "Menu"){
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
        isPF = true;
        diff = 60;
        PF_text.text = "You have chosen P/F as your passing garde.";
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
            }
            else if(cf.msg == "Computer" ){
                day = LoadDayData();
            }
            SceneManager.LoadScene(cf.msg);
        }
        savePlayerData();
        yes.SetActive(false);
        no.SetActive(false); 
    }


}
