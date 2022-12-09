using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitch : MonoBehaviour
{

    public string input;
    // private bool isConfirm;
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
            SceneManager.LoadScene("Dorm");
        }
        if (input == "Tips" || input == "tips"){
            SceneManager.LoadScene("Tips");
        }
    }

    public void confirmBox(string msg){
        
        if (msg == "yes"){
            // isConfirm = true;
            Debug.Log(cf.msg);
            SceneManager.LoadScene(cf.msg);
            if(cf.msg == "Classroom"){
                day+=1;
                day_text.text = "Day: " + day.ToString();
            }
        }
        yes.SetActive(false);
        no.SetActive(false); 
    }


}
