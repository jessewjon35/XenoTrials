using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public PlayerUI playerUi;

    public float currentTime;
    public float Seconds;
    public float Minutes;
    public float Hours;

    public bool timerStarted;

    public TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;

        playerUi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();

        timerStarted = false;
        timerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StopWatch();
    }

    public void StopWatch()
    {
        if(timerStarted == true)
        {
            timerText.gameObject.SetActive(true);

            currentTime += Time.deltaTime;
            Seconds = (int)(currentTime % 60);
            Minutes = (int)((currentTime / 60) % 60);
            Hours = (int)(currentTime / 3600);

            timerText.text = Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00");
        }
        
    }

}
