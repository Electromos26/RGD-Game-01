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
    public void StartDancing()
    {
        skillCheckGame.SetActive(true);
        slothAnim.SetBool("Dancing", true);

        //enable skill check
    }
   
    public void NextTurn()
    {
        skillCheckGame.SetActive(false);
        if (turnsLeft > 0)
        {
            ball.SpeedX2();
            turnsLeft--;
            
                
           Invoke("StartDancing", 3f);

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
        slothAnim.SetTrigger("Cry");

        if (finalPoints > -2)
            finalPoints--;

        NextTurn();
    }


    public void FinishMiniGame()
    {
        slothAnim.SetBool("Dancing", false);

        KingHappinessManager.Instance.AddHappiness(finalPoints);

        TransitionManager.Instance.SetState(TransitionManager.State.KingReacting);
    }
}
