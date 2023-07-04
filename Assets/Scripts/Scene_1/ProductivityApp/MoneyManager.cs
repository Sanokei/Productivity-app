using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using ProductivityApp;
using TMPro;
using System.Globalization;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text MoneyText;
    [SerializeField] GameObject wallTV;
    float _TotalMoney;
    [SerializeField] PlayableDirector MoneyGlitch;
    bool _MoneyGlitchBool = false;
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
        MoneyText.text = $"{_TotalMoney.ToString("C", CultureInfo.CreateSpecificCulture("en-us"))}";
    }

    void Update()
    {
        if(_TotalMoney > 10f && !_MoneyGlitchBool)
        {
            _MoneyGlitchBool = true;
            MoneyGlitch.Play();
        }
    }

    public void TurnMoneyWallTVOff()
    {
        wallTV.SetActive(false);
    }
}
