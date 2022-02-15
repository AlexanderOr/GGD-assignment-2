using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public string score;

    
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Score") + "";
    }
}