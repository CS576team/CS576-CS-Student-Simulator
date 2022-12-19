using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class resultScene : MonoBehaviour
{
    private Image panel_color;
    public TMP_Text result_text;
    public TMP_Text honor_text;
    public AudioClip passing;
    public AudioClip fail; 
    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        panel_color = gameObject.GetComponent<Image>();
        playerData pd = SaveData.Load();
        aS = gameObject.GetComponent<AudioSource>();
        
        if(pd.grade >= pd.diff){
            aS.clip = passing;
            panel_color.color = Color.green;
            result_text.text = "You pass the Class!";
            honor_text.text = "YOU PASSED THE CLASS WITH YOUR DESIRED PASSING GRADE!!!";
        } else {
            aS.clip = fail;
            panel_color.color = Color.red;
            result_text.text = "Sorry! you failed the class!";
            honor_text.text = "";
        }
        aS.Play();

        string path = "Assets/Scripts/Data/player.fun";
        File.Delete (path);
    }

}
