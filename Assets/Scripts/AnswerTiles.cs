using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTiles : MonoBehaviour
{
    private string correct_tile;

    private int attempts_num;
    public ClassroomUI ClassroomUI;

    void Start()
    {
        correct_tile = "TileB";
        attempts_num = 3;
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        Renderer render = GetComponent<Renderer>();
        string tile = gameObject.name;
        render.material.color = Color.blue;
        StartCoroutine(WaitForAnswer(tile, render));
    }

    IEnumerator WaitForAnswer(string tile, Renderer render) {
        yield return new WaitForSeconds(2);
        if (tile != correct_tile) {
            render.material.color = Color.red;
            attempts_num--;
            ClassroomUI.UpdateUI(attempts_num);
        } else {
            render.material.color = Color.green;
        }
     }

}
