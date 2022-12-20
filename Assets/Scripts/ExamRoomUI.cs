using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamRoomUI : MonoBehaviour
{
    public ExamRoomManager examroom;

    internal void LoseTime(float time_num)
    {
        float curtime = examroom.start_time;
        Debug.Log(curtime);
        examroom.start_time = curtime - time_num;
    }
}
