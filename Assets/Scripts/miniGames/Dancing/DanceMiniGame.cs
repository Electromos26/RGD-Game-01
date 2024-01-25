using UnityEngine;

public class DanceMiniGame : Singleton<DanceMiniGame>
{
    [SerializeField]
    private int turnLeft = 3;
    [SerializeField]
    private BallMovement ball;

    private int finalPoints = 0;

    [SerializeField]
    private GameObject skillCheckGame;

    private bool isDancing = false;
    public bool IsDancing { get { return isDancing; } set { isDancing = value; } }


    private void Awake()
    {
        
    }
     
    public void StartDancing()
    {
        isDancing = true;
        skillCheckGame.SetActive(true);

       //enable skill check
    }
    void StopDancing()
    {
        isDancing = false;

        //disable skill check
    }
    public void NextTurn()
    {
        skillCheckGame.SetActive(false);
        StopDancing();
        if (turnLeft > 0)
        {
            turnLeft--;
        }
        ball.SpeedX2();
        //show animation 
        Invoke("StartDancing", 3f); //use Aniamtion event to call this


    }

    public void Passed()
    {
   if (finalPoints < 2)
        {
            NextTurn();
            finalPoints++;
           
        }
    }
    public void Failed()
    {
   if (finalPoints > -2)
        {
            NextTurn();
            finalPoints--;
        }
    }
 

   
    private void Update()
    {
        if (turnLeft <= 0)
        {
            FinishMiniGame();
        }
    }
    public void FinishMiniGame()
    {
        KingHappinessManager.Instance.AddHappiness(finalPoints);

        TransitionManager.Instance.SetState(TransitionManager.State.KingReacting);
    }
}
