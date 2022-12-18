using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class playerData
{
    public int day;
    public int grade;
    public int diff;
    public bool isPF;
    

    public playerData(SceneSwitch ss){
        Debug.Log("playerData: ss.day = " +ss.day + " ss.diff = " + ss.diff);
        day = ss.day;
        diff = ss.diff;
        grade = ss.grade;
        isPF = ss.isPF;
        
    }
    public playerData(){//default
        Debug.Log("playerData: Init day = 0 grade = 100 ");
        day = 0;
        grade = 100;
        diff = 60;
        isPF = false;
        
    }
}
