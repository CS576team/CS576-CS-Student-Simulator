using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class screen : MonoBehaviour
{
    public TMP_Dropdown dd;
    public GameObject defaultPanel;
    public GameObject grade;
    public GameObject requirement;
    public GameObject review;
    public GameObject rules;
    public TMP_Text dayzerotext;
    public TMP_Text gradetext;
    public TMP_Text advisor_text;

    public Dropdown qd;

    public string[] questions;
    public string[] days;
    public TMP_Text question_text;

    void Start() {
        questions = new string[6];
        days = new string[6];
        for (int a = 0; a < 6; a++){
            days[a] = "day "+ (a+1).ToString();

        }
        questions[0] = "How do you print " + "\"Hello World\"" + " in Java?" + "\n"
                        + "A) console.log(\"Hello World\")" + "\n" 
                        + "B) System.out.println(\"Hello World\");" + "\n"
                        + "C) print(\"Hello World\")" + "\n"
                        + "D) Debug.Log(\"Hello World\");";
    
        questions[1] = "What is the correct syntax for a for loop in Java?" + "\n"
                        + "A) for i in arr:" + "\n" 
                        + "B) for (let i = 0; i < n; i++) { }" + "\n"
                        + "C) for (int i = 0; i < n; i++) { }" + "\n"
                        + "D) for (i < n; i++; int i = 0) { }";
                    
        questions[2] = "Exam day 1";
    
        questions[3] = "Stacks follow the __ principle, while Queues follow the __ principle." + "\n"
                        + "A) LIFO, FIFO" + "\n" 
                        + "B) Array, List" + "\n"
                        + "C) FILO, OFIF" + "\n"
                        + "D) FIFO, LIFO";

        questions[4] = "In Java, inheriting from a class uses the ___ keyword, while using an interface uses the ___ keyword." + "\n"
                        + "A) implements, extends" + "\n" 
                        + "B) is, using" + "\n"
                        + "C) implement, extend" + "\n"
                        + "D) extends, implements";
        
        questions[5] = "Exam day 2";
       
    }

    public void panelSwitch(){
        Debug.Log(dd.value);
        playerData pd = SaveData.Load();
        if(dd.value == 0){
            defaultPanel.SetActive(true);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(false);
        } else if (dd.value == 1){
            defaultPanel.SetActive(false);
            grade.SetActive(true);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(false);
            gradetext.text = "Your current grade is: " + pd.grade;
            if (pd.grade <= pd.diff && pd.day < 4){
                advisor_text.text = "Adisor Comment: You need to work harder! Maybe consider P/F option before day 4?"; 
            } else if (pd.grade <= pd.diff){
                advisor_text.text = "Adisor Comment: You need to work harder!";
            }
        } else if (dd.value == 2){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(true);
            review.SetActive(false);
            rules.SetActive(false);
        } else if (dd.value == 3){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(true);
            rules.SetActive(false);
            Debug.Log("pd.day = "+ pd.day);
            dayzerotext.text = "";
            if(pd.day == 0){
                dayzerotext.text = "You haven't taken any classes yet!"+"\nPlaese go to class first!";
            }
            
            qd.ClearOptions();
            List<string> list = new List<string>();
            
            for(int d = 0; d< pd.day; d++){
                Debug.Log("d: "+d);
                Debug.Log("questions["+d+"]: "+ days[d]);
                list.Add(days[d]);

            }
            qd.AddOptions(list);
            
        } else if (dd.value == 4){
            defaultPanel.SetActive(false);
            grade.SetActive(false);
            requirement.SetActive(false);
            review.SetActive(false);
            rules.SetActive(true);
        }


    }

    public void show(int x){
        question_text.text = questions[x];
    }
}
