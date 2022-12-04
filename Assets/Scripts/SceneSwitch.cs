using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string input;

    
    
    public void switchScene(string scenename)
    {
        Debug.Log(scenename);
        SceneManager.LoadScene(scenename);
    }

    public void readInput(string i){
        input = i;
        Debug.Log(input);
        if (input == "Start" || input == "start"){
            SceneManager.LoadScene("Dorm");
        }
    }


}
