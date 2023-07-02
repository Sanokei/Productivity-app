using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProductivityApp;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text MoneyText;
    float _TotalMoney;
    public static MoneyManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }

    void OnEnable()
    {
        ProductivityTimer.TimerFinishEvent += AddMoney;
    }

    void OnDisable()
    {
        ProductivityTimer.TimerFinishEvent -= AddMoney;
    }

    void AddMoney(ProductivityTimer timer)
    {
        _TotalMoney += timer.Time / 1000f;
        MoneyText.text = $"${_TotalMoney}";
    }
}
