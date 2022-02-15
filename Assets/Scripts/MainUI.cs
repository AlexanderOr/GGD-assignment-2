using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public int Points;
    public int Lives;
    public int MaxLives = 3;
    public Text livesText;
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        MaxLives = Lives;
        Points = 0;
    }

    public void LifeLoss()
    {
        Lives = Lives - 1;
        livesText.text = Lives + " / " + MaxLives;
    }
}
