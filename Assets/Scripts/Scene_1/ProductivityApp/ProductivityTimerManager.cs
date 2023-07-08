using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;
using TMPro;
using System;

namespace ProductivityApp
{
    public class ProductivityTimerManager : MonoBehaviour
    {
        List<ProductivityTimer> timers = new List<ProductivityTimer>();
        [SerializeField] TMP_Text text;
        public static ProductivityTimerManager Instance;

        void Awake()
        {
            if(Instance)
                Destroy(this);
            else
                Instance = this;
        }
        void OnEnable()
        {
            ProductivityAddTimerButton.TimerCreateEvent += (t) => {Instance.timers.Add(t);};
            ProductivityTimer.TimerFinishEvent += (t) => {Instance.timers.Remove(t);};
        }

        void OnDisable()
        {
            ProductivityAddTimerButton.TimerCreateEvent -= (t) => {Instance.timers.Add(t);};
            ProductivityTimer.TimerFinishEvent -= (t) => {Instance.timers.Remove(t);};
        }

        void Update()
        {
            if(timers.Count > 0)
            {
                if(TimersManager.IsTimerPaused(timers[0].Timer))
                {
                    TimersManager.SetPaused(timers[0].Timer, false);
                }
                float timeRemaining = TimersManager.RemainingTime(timers[0].Timer);
                TimeSpan t = TimeSpan.FromSeconds( timeRemaining );
                text.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
                        t.Hours, 
                        t.Minutes, 
                        t.Seconds
                        );
            }
            if(timers.Count == 0 && text.text != "00:00:00")
            {
                text.text = "00:00:00";
            }
        }
    }
}