using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    public float time = 0;
    public bool runTimer = false;
    public TextMeshProUGUI timeText;

    private static TimeManager _instance;

    public static TimeManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Time Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(runTimer)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    public void LogTime()
    {
        runTimer = false;

        time = time + (GameManager.Instance.civiTargetsShot * 2) + (GameManager.Instance.enemyTargets.Count - GameManager.Instance.enemyTargetsShot);

        GameManager.Instance.currentTime = time;

        //format time
        time += 1;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;
        string timetext = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        Debug.Log("Time taken: " + timetext);
        GameManager.Instance.finalTimePopup.SetActive(true);
        GameManager.Instance.timeToDisplay = timetext;
        GameManager.Instance.finalTimeText.text = timetext;

        time = 0;
    }

    public void StartTimer()
    {
        time = 0;
        runTimer = true;
    }

    public void StopTimer()
    {
        LogTime();  
    }
}
