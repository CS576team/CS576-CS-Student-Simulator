using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTiles : MonoBehaviour
{
    private string correct_tile;

    public ClassroomUI ClassroomUI;

    void Start()
    {
        correct_tile = "TileB";
        PlayerPrefs.SetInt("attempts", 3);
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log(gameObject);
        // if (other.name == "Player") { 
        //     Debug.Log("hi");
        // }
        Renderer render = GetComponent<Renderer>();
        string tile = gameObject.name;
        render.material.color = Color.blue;
        StartCoroutine(WaitForAnswer(tile, render));
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
        }
     }

}
