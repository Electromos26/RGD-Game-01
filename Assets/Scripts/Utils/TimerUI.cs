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

    public void SetCurrentTimer(float time)
    {
        //slider.value = health;
        slider.value = (slider.maxValue - time);
        GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
        if(slider.value <= 0.1f)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Turnoff()
    {
        this.gameObject.SetActive(false);
    }
}

