using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent EndOfTimer;

    private float timer = 0.0f;

    [SerializeField] private float timeLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            EndOfTimer.Invoke();
            timer = 0f;
        }
    }
}
