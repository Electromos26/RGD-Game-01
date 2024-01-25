using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingHappinessManager : Singleton<KingHappinessManager>
{
    private int kingHappiness;

    // Start is called before the first frame update
    void Start()
    {
        kingHappiness = 5;
    }

    public void AddHappiness(int addedPoints)
    {
        kingHappiness += addedPoints;
        if (kingHappiness >= 10)
        {
            //Play king laughing animation
            //Load winning screen
        }
        else if (kingHappiness <= 0)
        {
            Player_Lives.Instance.SubtractLives(1);
            kingHappiness = 5;
        }
        Debug.Log(kingHappiness);
    }



}
