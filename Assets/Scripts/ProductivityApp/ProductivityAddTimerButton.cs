using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProductivityApp
{
    public class ProductivityAddTimerButton : MonoBehaviour
    {
        public delegate void TimerCreate(ProductivityTimer timer);
        public static event TimerCreate TimerCreateEvent;

        [SerializeField] ProductivityTimer Prefab;
        [SerializeField] Transform Parent;

        [SerializeField] TMP_InputField text;
        [SerializeField] Slider slider;


        public void AddTimerButtonClick()
        {
            ProductivityTimer PTM = Instantiate(Prefab,Parent);
            PTM.CreateTimer(slider.value, text.text);

            // reset inputs
            slider.value = 1;
            text.text = "";

            TimerCreateEvent?.Invoke(PTM);
        }
    }
}