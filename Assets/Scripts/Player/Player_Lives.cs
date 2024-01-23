using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lives : Singleton<Player_Lives>
{
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    public int _lives   // property
    {
        get { return lives; }   // get method
        set { lives = value; }  // set method
    }

    public void SubtractLives(int damage)
    {
        lives -= damage;
        //Reduce one face from UI
        if (lives <= 0)
        {
            //Play king laughing animation
            //Play Death animation
            //Load Lose screen screen
        }
    }
}
