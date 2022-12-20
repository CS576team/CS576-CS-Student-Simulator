using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamRoomFunc : MonoBehaviour
{
    public ExamRoomUI ExamRoomUI;
    public ExamRoomManager ExamroomManager;

    void Start() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") { 
            Renderer render = GetComponent<Renderer>();
            string tile = gameObject.name;
            render.material.color = Color.blue;
            ExamroomManager.PlaySound("tile");
            StartCoroutine(WaitForAnswer(tile, render));
        }
    }

    IEnumerator WaitForAnswer(string tile, Renderer render) {
        yield return new WaitForSeconds(2);
        if (tile != "TileB") {
            render.material.color = Color.red;
            ExamroomManager.PlaySound("incorrect");
            ExamRoomUI.LoseTime(10.0f);
        } else {
            render.material.color = Color.green;
            PlayerPrefs.SetString("player_pass", "true");
        }
     }
}
