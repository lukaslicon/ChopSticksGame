using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using Unity.VisualScripting;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeText;
    private float elapsedTime = 0f;
    public StartGame gameStart;
    void Update()
    {
        if(gameStart.isStarted == true)
        {
            elapsedTime += Time.deltaTime;
            timeText.text = "Time: " + elapsedTime.ToString("F2");
        }

    }
    

}

