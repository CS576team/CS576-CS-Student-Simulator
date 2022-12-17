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

    public AudioClip Correct_Answer;
    public AudioClip Garbage_collide;
    public AudioClip Incorrect_Answer;
    public AudioClip Fail;
    public AudioClip Book;
    public AudioClip Tile_clicked;
    private AudioSource audioSource; 

    void Start() {
        is_day_over = false;
        PlayerPrefs.SetString("player_pass", "false");
        PlayerPrefs.SetString("player_destroyed", "false");
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update() {
        ClassroomEnd();
    }

    void ClassroomEnd() {
        int attempts = PlayerPrefs.GetInt("attempts");
        string passed = PlayerPrefs.GetString("player_pass");
        if (!is_day_over && attempts <= 0) {
            audioSource.clip = Fail;
            audioSource.Play();
            is_day_over = true;
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
        if (clip == "garbage") {
            audioSource.clip = Garbage_collide;
        } 
        if (clip == "incorrect") {
            audioSource.clip = Incorrect_Answer;
        }
        if (clip == "book") {
            audioSource.clip = Book;
        }
        if (clip == "tile") {
            audioSource.clip = Tile_clicked;
        }
        audioSource.Play();
    }
}
