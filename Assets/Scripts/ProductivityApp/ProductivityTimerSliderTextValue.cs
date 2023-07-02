using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProductivityApp
{
    public class ProductivityTimerSliderTextValue : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] Slider slider;
        
        void OnEnable()
        {
            ProductivityManager.ProductivityAppActiveEvent += ActiveApp;
        }
        void OnDisable()
        {
            ProductivityManager.ProductivityAppActiveEvent -= ActiveApp;
        }
        public void ActiveApp()
        {
            text.text = $"{slider.value.ToString()}:00";
        }
    }
}