using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : Singleton<TransitionManager>
{
    public List<GameObject> miniGames = new();

    private GameObject currentMiniGame;

    public enum State
    {
        kingChoosing,
        miniGame,
        KingReacting
    }
    public State currentState;

    private void Start()
    {
        SetState(State.kingChoosing);
    }

    public void SetState(State newState)
    {
        currentState = newState;
        StopAllCoroutines();
        switch (currentState)
        {
            case State.kingChoosing:
                OnKingChoosing();
                break;
            case State.KingReacting:
                StartCoroutine(OnKingReacting());
                break;
            default:
                break;
        }

    }
    void OnKingChoosing()
    {
        Debug.Log("Choosing");

        Invoke("SelectMiniGame", 3f);
        // currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];//is this the right way to do this?fixxxxx 
        // oWe need to choose one minigame from the random list
    }
    IEnumerator OnKingReacting()
    {
        yield return new WaitForSeconds(1f);

        SetState(State.kingChoosing);

    }

    private void SelectMiniGame()
    {
        miniGames[0].gameObject.GetComponent<MiniGames>().OnMiniGameStart.Invoke();
    }


}
