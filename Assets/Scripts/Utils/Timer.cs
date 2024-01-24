using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent<float> StartOfTimer;
    public UnityEvent<float> UpdateOfTimer;
    public UnityEvent EndOfTimer;

    private float timer = 0.0f;

    [SerializeField] private float timeLimit;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartOfTimer.Invoke(timeLimit);
    }
    private void OnEnable()
    {
        timer = 0;
        StartOfTimer.Invoke(timeLimit);
    }

    // Update is called once per frame
    void Update()
    {

        UpdateOfTimer.Invoke(timer);
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > timeLimit)
        {
            EndOfTimer.Invoke();
            timer = 0f;
        }
    }
    
}
