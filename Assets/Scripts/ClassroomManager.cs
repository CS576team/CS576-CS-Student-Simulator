using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomManager : MonoBehaviour
{
    public GameObject player; 
    public GameObject end_cam;
    public WinScreen WinScreen;
    public LoseScreen LoseScreen;
    private bool is_day_over;

    void Start() {
        is_day_over = false;
        PlayerPrefs.SetString("player_pass", "false");
        PlayerPrefs.SetString("player_destroyed", "false");
    }

    void Update() {
        ClassroomEnd();
    }

    void ClassroomEnd() {
        int attempts = PlayerPrefs.GetInt("attempts");
        string passed = PlayerPrefs.GetString("player_pass");
        if (!is_day_over && attempts <= 0) {
            is_day_over = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            end_cam.SetActive(true);
            Destroy(player);
            PlayerPrefs.SetString("player_destroyed", "true");
            LoseScreen.Setup();
        } else if (!is_day_over && passed == "true") {
            is_day_over = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            end_cam.SetActive(true);
            Destroy(player);
            PlayerPrefs.SetString("player_destroyed", "true");
            WinScreen.Setup();
        }
    }
}
