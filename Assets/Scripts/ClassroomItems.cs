using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomItems : MonoBehaviour
{
    public ClassroomUI ClassroomUI;
    private string correct_tile;

    void Start() {
        correct_tile = "TileB";
        PlayerPrefs.SetInt("attempts", 3);
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") { 
            if (gameObject.name.Contains("Book")) {
                Destroy(gameObject);
                int attempts = PlayerPrefs.GetInt("attempts");
                attempts++;
                PlayerPrefs.SetInt("attempts", attempts);
                ClassroomUI.UpdateUI(attempts);
            } else { 
                Renderer render = GetComponent<Renderer>();
                string tile = gameObject.name;
                render.material.color = Color.blue;
                StartCoroutine(WaitForAnswer(tile, render));
            }
        }
    }

    IEnumerator WaitForAnswer(string tile, Renderer render) {
        yield return new WaitForSeconds(2);
        if (tile != correct_tile) {
            render.material.color = Color.red;
            int attempts = PlayerPrefs.GetInt("attempts");
            attempts--;
            PlayerPrefs.SetInt("attempts", attempts);
            ClassroomUI.UpdateUI(attempts);
        } else {
            render.material.color = Color.green;
            PlayerPrefs.SetString("player_pass", "true"); 
        }
     }

}
