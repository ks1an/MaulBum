using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public Action OnTimerZero;
    public float timeStart = 60;
    public float currentTime;
    private TMP_Text _timerText;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(currentTime).ToString();
        if(currentTime <= 0)
        {
            OnTimerZero?.Invoke();
        }
    }
    public void StartTimer()
    {
        _timerText = GetComponent<TMP_Text>();
        currentTime = timeStart;
    }
}
