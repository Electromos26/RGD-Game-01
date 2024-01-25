using UnityEngine;
public class DanceMiniGame : Singleton<DanceMiniGame>
{
    [SerializeField]
    private int turnsLeft = 4;
    [SerializeField]
    private BallMovement ball;

    private int finalPoints = 0;
    private int resetValue;
    [SerializeField]
    private GameObject skillCheckGame;

    private void Awake()
    {
        resetValue = turnsLeft;
    }
    public void StartDancing()
    {
        skillCheckGame.SetActive(true);

        //enable skill check
    }
    void StopDancing()
    {

        //disable skill check
    }
    public void NextTurn()
    {
        skillCheckGame.SetActive(false);
        StopDancing();
        if (turnsLeft > 0)
        {
            ball.SpeedX2();
            turnsLeft--;
                                        //play animation
            Invoke("StartDancing", 3f); //use Aniamtion event to call this
                                        //Also disable timer UI at the starty of animation using event

        }
        else if (turnsLeft <= 0)
        {
            Debug.Log("Finish dance Mini Game");
            FinishMiniGame();
            return;
        }
    }

    public void ResetGame()
    {
        turnsLeft = resetValue;
        finalPoints = 0;
    }

    public void Passed()
    {

        if (finalPoints < 2)
            finalPoints++;
        NextTurn();
    }
    public void Failed()
    {

        if (finalPoints > -2)
            finalPoints--;
        NextTurn();
    }


    public void FinishMiniGame()
    {
        KingHappinessManager.Instance.AddHappiness(finalPoints);

        TransitionManager.Instance.SetState(TransitionManager.State.KingReacting);
    }
}
