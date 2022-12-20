using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public GameObject player_obj;
    private float radius_of_search_for_player;
    private float teacher_speed;
    private Vector3 teacher_position;
    private Vector3 player_position;
    public ExamFailScreen LoseScreen;
    public GameObject end_cam;
    public ExamRoomManager ExamroomManager;

    // Start is called before the first frame update
    void Start()
    {
        radius_of_search_for_player = 100.0f;
        teacher_speed = 2.5f;
        teacher_position = transform.position;
        player_position = player_obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("player_destroyed") != "true") {
            if (Vector3.Distance(player_obj.transform.position, teacher_position) < radius_of_search_for_player)
            {
                teacher_position = Vector3.MoveTowards(teacher_position, player_obj.transform.position, teacher_speed * Time.deltaTime);
                transform.position = teacher_position;
            }
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            transform.LookAt(player_obj.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Game Over");
            // ExamroomManager.PlaySound("fail");
            // PlayerPrefs.SetString("player_destroyed", "true");
            // Destroy(player_obj);
            // end_cam.SetActive(true);
            // LoseScreen.Setup();
            ExamroomManager.caught = true;
        }
    }

}