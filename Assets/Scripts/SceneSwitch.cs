using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
    
    public void switchScene(string scenename)
    {
        Debug.Log(scenename);
        if (scenename == "Computer"){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(scenename);
    }

    public void readInput(string i){
        input = i;
        Debug.Log(input);
        if (input == "Start" || input == "start"){
            BinaryFormatter f = new BinaryFormatter();
            string path = "Assets/Scripts/Data/player.fun";
            File.Delete (path);
            
            SceneManager.LoadScene("Dorm");
        }
        if (input == "Tips" || input == "tips"){
            SceneManager.LoadScene("Tips");
        }
    }

    public void confirmBox(string msg){
        Debug.Log("confirmbox appeared!");
        if (msg == "yes"){
            Debug.Log("scene:"+cf.msg); 
            if(cf.msg == "Classroom" || cf.msg == "ExamRoom" ){
                day = LoadData() +1;
            }
            SceneManager.LoadScene(cf.msg);
        }
        yes.SetActive(false);
        no.SetActive(false); 
    }

    public void savePlayerData(){
        SaveData.SavePlayer(this);
    }
    public int LoadData(){
        playerData data = SaveData.Load();
        return data.day;
        
    }
    public void LoadPlayerData(){
        playerData data = SaveData.Load();
        day = data.day;
        day_text.text = "Day: " + day;
    }


}
