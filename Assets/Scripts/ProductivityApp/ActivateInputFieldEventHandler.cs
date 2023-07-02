using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProductivityApp;

public class ActivateInputFieldEventHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    void Start()
    {
        input.enabled = false;
    }
    void OnEnable()
    {
        ProductivityManager.ActivateInputFieldEvent += ActivateInputField;
    }

    void OnDisable()
    {
        ProductivityManager.ActivateInputFieldEvent -= ActivateInputField;
    }

    void ActivateInputField(bool x)
    {
        input.enabled = x;
    }
}
