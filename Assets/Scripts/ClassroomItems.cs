using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomItems : MonoBehaviour
{
    public ClassroomUI ClassroomUI;
    public ClassroomManager ClassroomManager;

    void Start() {
        PlayerPrefs.SetInt("attempts", 3);
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") { 
            if (gameObject.name.Contains("Book")) {
                Destroy(gameObject);
                ClassroomManager.PlaySound("book");
                int attempts = PlayerPrefs.GetInt("attempts");
                attempts++;
                PlayerPrefs.SetInt("attempts", attempts);
                ClassroomUI.UpdateUI(attempts);
            } else { 
                Renderer render = GetComponent<Renderer>();
                string tile = gameObject.name;
                Debug.Log("tile being stepped on: " + tile);
                render.material.color = Color.blue;
                ClassroomManager.PlaySound("tile");
                StartCoroutine(WaitForAnswer(tile, render));
            }
        }
    }

    IEnumerator WaitForAnswer(string tile, Renderer render) {
        yield return new WaitForSeconds(2);
        // Debug.Log("Stepped on tile: " + tile);
        // Debug.Log("Correct tile: "+ PlayerPrefs.GetString("answer_tile"));
        playerData data = SaveData.Load();
        if (tile != PlayerPrefs.GetString("answer_tile")) {
            render.material.color = Color.red;
            int attempts = PlayerPrefs.GetInt("attempts");
            attempts--;
            PlayerPrefs.SetInt("attempts", attempts);
            ClassroomManager.PlaySound("incorrect");
            ClassroomUI.UpdateUI(attempts);
            //int grade = PlayerPrefs.GetInt("grade");
            int grade = data.grade;
            grade -= 5;
            PlayerPrefs.SetInt("grade", grade);
        } else {
            render.material.color = Color.green;
            PlayerPrefs.SetString("player_pass", "true"); 
        }
     }

}
