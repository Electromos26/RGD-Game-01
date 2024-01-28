using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float Difficulty
    {
        get; set;
    }
    private void Awake()
    {
        this.Difficulty = 1f;
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))  //only game jam
            Application.Quit();
    }
}
