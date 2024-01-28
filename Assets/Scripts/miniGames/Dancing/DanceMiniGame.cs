using UnityEngine;
public class DanceMiniGame : Singleton<DanceMiniGame>
{

    [SerializeField]
    private int turnsLeft = 4;
    [SerializeField]
    private BallMovement ball;

    [SerializeField]
    private GameObject skillCheckGame;
    [SerializeField]
    Animator slothAnim;

    private int finalPoints = 0;
    private int resetValue;

    private void Awake()
    {
        resetValue = turnsLeft;
    }
    public void ShowHats()
    {
        FeedBackManager.Instance.AddHats(turnsLeft);
    }

    public void StartDancing()
    {
        skillCheckGame.SetActive(true);
        slothAnim.SetBool("Dancing", true);

        //enable skill check
    }
   
    public void NextTurn()
    {
        skillCheckGame.SetActive(false);
        turnsLeft--;

        slothAnim.SetFloat("DanceMultiplier", ball.Speed);

        if (turnsLeft > 0)
        {
            ball.SpeedX2();
           
           Invoke("StartDancing", 2.5f);

        }
        else if (turnsLeft <= 0)
        {
            Debug.Log("Finish dance Mini Game");
           
            FinishMiniGame();
           
        }
    }

    public void ResetGame()
    {
        turnsLeft = resetValue;
        finalPoints = 0;
        slothAnim.SetFloat("DanceMultiplier", ball.Speed);
    }

    public void Passed()
    {
        slothAnim.SetTrigger("Success");
        slothAnim.SetBool("Dancing", false);
        FeedBackManager.Instance.ChangeColor(true);

        if (finalPoints < GameConstants.HAPPINESS_MODIFIER)
            finalPoints++;
        NextTurn();
    }

    public void Failed()
    {

        slothAnim.SetTrigger("Cry");
        slothAnim.SetBool("Dancing", false);
        FeedBackManager.Instance.ChangeColor(false);

        if (finalPoints > -GameConstants.HAPPINESS_MODIFIER)
            finalPoints--;

        NextTurn();
    }


    public void FinishMiniGame()
    {
        slothAnim.SetBool("Dancing", false);
        ball.ResetSpeed();
        KingHappinessManager.Instance.AddHappiness(finalPoints);

        TransitionManager.Instance.SetState(TransitionManager.State.KingReacting);
        FeedBackManager.Instance.Invoke("ClearHats",3f);
    }
}
