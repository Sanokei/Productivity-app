using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Timers;
using TMPro;

namespace ProductivityApp
{
    public class ProductivityTimer : MonoBehaviour // cant be statechange cuz of default functions (i.e OnDisable)
    {
        public delegate void TimerFinish(ProductivityTimer timer);
        public static event TimerFinish TimerFinishEvent;

        [SerializeField] TMP_Text TaskText;
        [SerializeField] TMP_Text TimeText;

        public float Time;
        
        public void CreateTimer(float minutes, string task)
        {
            TimersManager.SetTimer(this, minutes * 60f, Timer);
            TimersManager.SetPaused(Timer, true);
            TaskText.text = task;
            float timeRemaining = TimersManager.RemainingTime(Timer);
            Time = timeRemaining;
            TimeText.text = $"{(int)timeRemaining/3600:00}:{(int)timeRemaining/60:00}:{(int)timeRemaining%60:00}";
        }
        public void Timer()
        {
            Destroy(gameObject);
        }

        void OnDisable()
        {
            TimerFinishEvent?.Invoke(this);
            TimersManager.ClearTimer(Timer);
        }

        public void DeleteButton()
        {
            Destroy(gameObject);
        }

        public void AddTimeButton()
        {
            float timeRemaining = TimersManager.RemainingTime(Timer);
            TimersManager.ClearTimer(Timer);
            TimersManager.SetTimer(this, timeRemaining + 300f, Timer);
        }
        public void SubTimeButton()
        {
            float timeRemaining = TimersManager.RemainingTime(Timer);
            if(timeRemaining - 300f <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                TimersManager.ClearTimer(Timer);
                TimersManager.SetTimer(this, timeRemaining - 300f, Timer);
            }
        }
    }
}