using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Questions : MonoBehaviour
{

    // public ClassroomItems ClassroomItems;
    public string[] questions; 
    public string[] answers;
    public GameObject question_text;
    private int day;

    public void LoadDayData(){
        playerData data = SaveData.Load();
        day = data.day;
    } 


    void Start() {
        LoadDayData();
        //day = 1; // Load day here
        Debug.Log("day from classroom:"+ day);
        questions = new string[6];
        answers = new string[6];
        questions[0] = "How do you print " + "\"Hello World\"" + " in Java?" + "\n"
        + "A) console.log(\"Hello World\")" + "\n" 
        + "B) System.out.println(\"Hello World\");" + "\n"
        + "C) print(\"Hello World\")" + "\n"
        + "D) Debug.Log(\"Hello World\");";
        answers[0] = "TileB";
        questions[1] = "What is the correct syntax for a for loop in Java?" + "\n"
        + "A) for i in arr:" + "\n" 
        + "B) for (let i = 0; i < n; i++) { }" + "\n"
        + "C) for (int i = 0; i < n; i++) { }" + "\n"
        + "D) for (i < n; i++; int i = 0) { }";
        answers[1] = "TileC";
        questions[2] = "Exam day 1";
        answers[2] = "Exam";
        questions[3] = "Stacks follow the __ principle, while Queues follow the __ principle." + "\n"
        + "A) LIFO, FIFO" + "\n" 
        + "B) Array, List" + "\n"
        + "C) FILO, OFIF" + "\n"
        + "D) FIFO, LIFO";
        answers[3] = "TileA";
        questions[4] = "In Java, inheriting from a class uses the ___ keyword, while using an interface uses the ___ keyword." + "\n"
        + "A) implements, extends" + "\n" 
        + "B) is, using" + "\n"
        + "C) implement, extend" + "\n"
        + "D) extends, implements";
        answers[4] = "TileD";
        questions[5] = "Exam day 2";
        LoadQuestions();
    }

    void LoadQuestions() {
        question_text.GetComponent<TextMeshPro>().text = questions[day - 1];
        PlayerPrefs.SetString("answer_tile", answers[day - 1]);
        Debug.Log(questions[day-1]);
        Debug.Log(PlayerPrefs.GetString("answer_tile"));
    }
}
