using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerUI : Singleton<TimerUI>
{

    [SerializeField] Color Low;
    [SerializeField] Color High;
    [SerializeField]
    private Slider slider;
    private void Start()
    {
    
    }
   
    public void SetMaxTime(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
    }
}

