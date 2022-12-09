using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterFunction : MonoBehaviour
{

    public GameObject yes;
    public GameObject no;
    public string msg;
    public TMP_Text confirm_text;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            confirm_text.text = "Leave Dorm";
            yes.SetActive(true);
            no.SetActive(true);
        }
    }
}
