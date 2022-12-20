using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamRoomManager : MonoBehaviour
{
    public GameObject player; 
    public GameObject end_cam;
    public ExamPassScreen WinScreen;
    public ExamFailScreen LoseScreen;
    private bool is_day_over;
    public bool caught;
    public float start_time = 80.0f;
    public TextMeshProUGUI time_text;

    public AudioClip Correct_Answer;
    public AudioClip Incorrect_Answer;
    public AudioClip Tile_clicked;
    public AudioClip Fail;
    private AudioSource audioSource; 

    void Start() {
        is_day_over = false;
        caught = false;
        PlayerPrefs.SetString("player_pass", "false");
        PlayerPrefs.SetString("player_destroyed", "false");
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update() {
        float t = start_time - Time.time;
        if (t < 0.0f || is_day_over) {
            t = 0.0f;
        }
        time_text.text = "Time: " + t.ToString("F0");
        string destroyed = PlayerPrefs.GetString("player_destroyed");
        if (destroyed != "true") {
            ExamroomEnd(t);
        }
    }

    void ExamroomEnd(float t) {
        string passed = PlayerPrefs.GetString("player_pass");
        if (t <= 0.0f && !is_day_over || caught) {
            // grade subtract 20
            is_day_over = true;
            audioSource.clip = Fail;
            audioSource.Play();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            end_cam.SetActive(true);
            Destroy(player);
            PlayerPrefs.SetString("player_destroyed", "true");
            LoseScreen.Setup();
        } else if (!is_day_over && passed == "true") {
            is_day_over = true;
            audioSource.clip = Correct_Answer;
            audioSource.Play();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            end_cam.SetActive(true);
            Destroy(player);
            PlayerPrefs.SetString("player_destroyed", "true");
            WinScreen.Setup();
        }
    }

    internal void PlaySound(string clip) {
        if (clip == "incorrect") {
            audioSource.clip = Incorrect_Answer;
        }
        if (clip == "tile") {
            audioSource.clip = Tile_clicked;
        }
        if (clip == "correct") {
            audioSource.clip = Correct_Answer;
        }
        if (clip == "fail") {
            audioSource.clip = Fail;
        }
        audioSource.Play();
    }
}
