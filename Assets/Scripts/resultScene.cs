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
        
        if(pd.grade >= pd.diff && pd.isPF == false){
            aS.clip = passing;
            panel_color.color = new Color((float)0.900,(float)1.000,(float)0.800);
            result_text.text = "You pass the Class!";
            honor_text.text = "YOU PASSED THE CLASS WITH YOUR DESIRED PASSING GRADE!!!";
        } else if(pd.grade >= pd.diff && pd.isPF == true){
            aS.clip = passing;
            panel_color.color = Color.yellow;
            result_text.text = "Restart! \n Get a better grade!";
            honor_text.text = "YOU PASSED THE CLASS !!!";
        }else {
            aS.clip = fail;
            panel_color.color = Color.magenta;
            result_text.text = "Sorry! you failed the class!";
            honor_text.text = "";
        }
        aS.Play();

        string path = "Assets/Scripts/Data/player.fun";
        File.Delete (path);
    }

}
