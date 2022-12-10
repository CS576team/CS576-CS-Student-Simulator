using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveData
{
    public static void SavePlayer (SceneSwitch ss){
        Debug.Log("saving day working correct");
        BinaryFormatter f = new BinaryFormatter();
        string path = "Assets/Scripts/Data/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(ss);

        f.Serialize(stream, data);
        stream.Close();
    }
    public static playerData Load(){
        string path = "Assets/Scripts/Data/player.fun";
        if (File.Exists(path)){
            BinaryFormatter f = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            playerData data = f.Deserialize(stream) as playerData;
            stream.Close();
            return data;

        } else{
            Debug.Log("data file not found!");
            BinaryFormatter f = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            playerData data = new playerData();
            f.Serialize(stream, data);
            stream.Close();
            return data;
        }
    }
    
}
