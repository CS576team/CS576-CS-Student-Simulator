using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GameObject player_obj;
    public ClassroomUI ClassroomUI;
    public ClassroomManager ClassroomManager;
    private float radius_of_search_for_player;
    private float garbage_speed;
    
    void Start() {
        garbage_speed = 3.2f;
        radius_of_search_for_player = 5.0f;
    }

    void Update() {
        if (PlayerPrefs.GetString("player_destroyed") != "true") { 
            // From CS576 Assignment 5, Virus.cs
            Color color = new Color{ r = Mathf.Max(1.0f, 0.25f + Mathf.Abs(Mathf.Sin(2.0f * Time.time))) };
            if (transform.childCount > 0) {
                transform.GetChild(0).GetComponent<MeshRenderer>().material.color = color;
            } else { 
                transform.GetComponent<MeshRenderer>().material.color = color;
            }
            transform.localScale = new Vector3(
                            1.2f + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time)), 
                            1.2f + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time)), 
                            1.2f + 0.2f * Mathf.Abs(Mathf.Sin(4.0f * Time.time))
                            );
            Vector3 v = player_obj.transform.position - transform.position;
            Vector3 d = v.normalized;
            float dist = Vector3.Distance(player_obj.transform.position, transform.position);
            if (dist <= radius_of_search_for_player) {
                transform.position += (new Vector3(d.x, 0.0f, d.z)) * (garbage_speed * Time.deltaTime);
            }
            transform.Rotate(new Vector3(0.0f, 0.1f, 0.0f));
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player") {
            int attempts = PlayerPrefs.GetInt("attempts");
            attempts--;
            PlayerPrefs.SetInt("attempts", attempts);
            Destroy(gameObject);
            ClassroomManager.PlaySound("garbage");
            ClassroomUI.UpdateUI(attempts);
        }
    }

}
