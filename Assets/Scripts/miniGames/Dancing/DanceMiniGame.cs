using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceMiniGame : Singleton<DanceMiniGame>
{
 
    [SerializeField]
    private int tries = 3;
    [SerializeField]
    private BallMovement ball;
    [SerializeField]
    private SkillCheck[] skillBoxes;
    int currentBox = 0;

    private void Awake()
    {
       
    }
    private void NextTurn()
    {
      ball.SpeedX2();
        currentBox++;
    } 
    
}
