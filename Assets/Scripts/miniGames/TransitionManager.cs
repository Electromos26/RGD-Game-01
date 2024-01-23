using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public List<GameObject> miniGames = new();

    private Dictionary<string, GameObject> miniGamesDict = new();

    private GameObject currentMiniGame;

    private enum State
    {
        kingChoosing,
        miniGame,
        KingReacting
    }
    private State currentState;

    private void Awake()
    {
        foreach (GameObject miniGame in miniGames)
        {
            miniGamesDict.Add(miniGame.name, miniGame);
        }
        currentState = State.kingChoosing;
    }

    public void StartMiniGame()
    {
        switch (currentState)
        {
            case State.kingChoosing:
                StartCoroutine(OnKingChoosing());
                break;
            case State.miniGame:
                StartCoroutine(OnMiniGame());
                break;

            case State.KingReacting:
                StartCoroutine(OnKingReacting());
                break;
            default:
                break;
        }

    }
    IEnumerator OnKingChoosing()
    {
        yield return new WaitForSeconds(1f);
       // currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];//is this the right way to do this?fixxxxx 

        currentState = State.miniGame;

    }
    IEnumerator OnMiniGame()
    {
        yield return new WaitForSeconds(1f);
        miniGames[Random.Range(0, miniGames.Count)].SetActive(false);
        currentState = State.KingReacting;
    }
    IEnumerator OnKingReacting()
    {
        yield return new WaitForSeconds(1f);
        miniGames[Random.Range(0, miniGames.Count)].SetActive(true);
        currentState = State.kingChoosing;
    }
}
