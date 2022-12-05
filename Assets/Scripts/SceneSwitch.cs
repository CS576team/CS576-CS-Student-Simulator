using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string input;
<<<<<<< HEAD
    
=======

>>>>>>> 4fc7d6e5d37d2e996e7531c09a11e89f0f7a365e
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
<<<<<<< HEAD
        if (input == "Tips" || input == "tips"){
            SceneManager.LoadScene("Tips");
        }
=======
>>>>>>> 4fc7d6e5d37d2e996e7531c09a11e89f0f7a365e
    }


}
