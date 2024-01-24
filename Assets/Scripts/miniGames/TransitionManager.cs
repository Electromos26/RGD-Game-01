using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public List<GameObject> miniGames = new();

    private GameObject currentMiniGame;

    private enum State
    {
        kingChoosing,
        miniGame,
        KingReacting
    }
    private State currentState;

    private void Start()
    {
        SetState(State.kingChoosing);
    }

    private void SetState(State newState)
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

        Invoke("RunFunction", 3f);
        // currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];//is this the right way to do this?fixxxxx 
        // oWe need to choose one minigame from the random list
    }
    IEnumerator OnKingReacting()
    {
        yield return new WaitForSeconds(1f);
        miniGames[Random.Range(0, miniGames.Count)].SetActive(true);
        SetState(State.kingChoosing);

    }

    private void RunFunction()
    {
        miniGames[0].gameObject.GetComponent<MiniGames>().OnMiniGameStart.Invoke();
    }


}
