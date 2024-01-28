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


        if (kingHappiness <= 0)
        {
            KingEmotion.Instance.SetEmotion(KingEmotion.emotion.rllyMad);
            Player_Lives.Instance.SubtractLives(1);
            kingHappiness = 5;
        }
        else if (kingHappiness >= 10)
        {
            KingEmotion.Instance.SetEmotion(KingEmotion.emotion.laughing);

           // TransitionManager.Instance.Invoke("LoadWinScene", 6f);
           
            //Load winning screen
        }
        else
        {
            if (addedPoints > 1)
            {
                KingEmotion.Instance.SetEmotion(KingEmotion.emotion.happy);


            }
            else if (addedPoints < -1)
            {
                KingEmotion.Instance.SetEmotion(KingEmotion.emotion.mad);
            }
            else
            {
                KingEmotion.Instance.SetEmotion(KingEmotion.emotion.neutral);
            }
        }

        Debug.Log(kingHappiness);
    }

}
