using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class playerData
{
    public int day;
    

    public playerData(SceneSwitch ss){
        Debug.Log("playerData: ss.day = " +ss.day);
        day = ss.day;
        
    }
    public playerData(){
        Debug.Log("playerData: Init day = 0 ");
        day = 0;
        
    }
}
