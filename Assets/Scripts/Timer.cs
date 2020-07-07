using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float timer;
    private float timertrimmed;
    public GameController GameController;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        timer = 0;
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
            timer += Time.deltaTime;
        }
        timertrimmed = (float)System.Math.Round(timer,2);
        text.text = "Czas:" + timertrimmed;
    }
}
