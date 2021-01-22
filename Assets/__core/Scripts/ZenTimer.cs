using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZenTimer : MonoBehaviour
{
    public Text TimerText;
    public Text StartStopButtonText;
    public bool isRunning = false;
    // default to ten minutes
    private float Timer = 600;
    private float TimerDuration = 600;
    public AudioSource singingBowlStrike;
    private bool initSound = false;

    // Update is called once per frame
    void Update()
    {
        if (isRunning == true)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                StartStopButtonText.text = "Start";
                isRunning = false;
                Timer = TimerDuration;
                playStopSound();
            }
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
        }
    }

    public void toggleStart()
    {
        if (!isRunning)
        {
            if (!initSound) {
                initSound = true;
            } else {
                playStartSound();
            }
        }
        StartStopButtonText.text = isRunning ? "Start" : "Pause";
        isRunning = !isRunning;
    }

    public void setPreDefined(float predefinedTimeInSeconds)
    {
        if (isRunning)
        {
            isRunning = false;
            StartStopButtonText.text = "Start";
        }
        Timer = predefinedTimeInSeconds;
        TimerDuration = Timer;
        int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer % 60F);
        TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
    }

    public void onSliderChange(float sliderTimeInMinutes)
    {
        if (isRunning)
        {
            isRunning = false;
            StartStopButtonText.text = "Start";
        }

        // slider increments by units of 5 minutes
        Timer = sliderTimeInMinutes * 60 * 5;
        TimerDuration = Timer;
        int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer % 60F);
        TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
    }

    public void playStartSound()
    {
        singingBowlStrike.Play();
        StartCoroutine("Delay", 15);
        StartCoroutine("Delay", 30);
    }

    public void playStopSound()
    {
        singingBowlStrike.Play();
    }

    IEnumerator Delay(float WaitSeconds)
    {
        yield return new WaitForSeconds(WaitSeconds);
        singingBowlStrike.Play();
        yield return null;
    }
}
