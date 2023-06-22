using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fase3Timer : MonoBehaviour
{
    [Header("GameObject:")]
    public Slider TimerSlider;
    private float _gameTime = 90.0f;
    private float _timer = 00.0f;
    private bool _stopTimer;

    private void Start()
    {
        _stopTimer = false;
        TimerSlider.minValue = 0.0f;
        TimerSlider.maxValue = _gameTime;
        TimerSlider.value = TimerSlider.minValue;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _gameTime)
        {
            _stopTimer = true;
            GetComponent<Fase3Manager>().WinMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (_stopTimer == false)
        {
            TimerSlider.value = _timer;
        }
    }
}
