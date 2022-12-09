using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTiles : MonoBehaviour
{
    private string correct_tile;

    void Start()
    {
        correct_tile = "TileB";
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
        } else {
            render.material.color = Color.green;
        }
     }

}
