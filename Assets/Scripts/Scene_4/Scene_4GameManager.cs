using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using Timers;
using TMPro;
using System;

public class Scene_4GameManager : MonoBehaviour
{
    [SerializeField] Image Fill;
    [SerializeField] PlayableDirector Game1;
    [SerializeField] PlayableDirector Game2;
    [SerializeField] PlayableDirector Game3;
    [SerializeField] TMP_Text text;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;        
    }
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
    }
    
    public void SubtractHealth()
    {
        Game1?.Stop();
        Fill.fillAmount -= 0.25f;
    }
    public void GoToGame1()
    {
        Game1.Play();
    }
    public void GoToGame2()
    {
        Game1?.Stop();
        Game2.Play();
    }
    public void GoToGame3()
    {
        Game2?.Stop();
        Game3.Play();
    }
    public void Timer()
    {

    }
    public void CreateTimer()
    {
        CreateTimer(10f);
    }
    public void CreateTimer(float time)
    {
        TimersManager.SetTimer(this, time, Timer);
        float timeRemaining = TimersManager.RemainingTime(Timer);
        TimeSpan t = TimeSpan.FromSeconds( timeRemaining );
        text.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
            t.Hours, 
            t.Minutes, 
            t.Seconds
        );
    }

    void Update()
    {
        float timeRemaining = TimersManager.RemainingTime(Timer);
        TimeSpan t = TimeSpan.FromSeconds( timeRemaining );
        text.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
            t.Hours, 
            t.Minutes, 
            t.Seconds
        );
    }
}
