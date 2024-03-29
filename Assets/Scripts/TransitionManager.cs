using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public List<GameObject> miniGames = new();
    [SerializeField] private GameObject kingSpeakingBox;

    private GameObject currentMiniGame;

    private int currentGameSelec = 0;

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
                StartCoroutine(OnKingChoosing());
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
        yield return new WaitForSeconds(3f);

        KingEmotion.Instance.TriggerChoosingAnim();

        SelectMiniGame();
        // currentMiniGame = miniGames[Random.Range(0, miniGames.Count)];//is this the right way to do this?fixxxxx 

        //trigger animation of king choosing

        // oWe need to choose one minigame from the random list
    }
    IEnumerator OnKingReacting()
    {
        //Show Kings Reaction on top of its head
        yield return new WaitForSeconds(0.5f);
        KingEmotion.Instance.PlayEmotionClip();
        Debug.Log("Reacting");

        SetState(State.kingChoosing);

    }

    public void LoadWinScene()
    {
        //Load Win screen
        SceneManager.LoadScene("03_WinScreen");
    }
    public void LoadLoseScene()
    {

        SceneManager.LoadScene("04_LoseScreen");

    }
    private void SelectMiniGame()
    {

        currentGameSelec = (currentGameSelec + 1) % miniGames.Count;
        kingSpeakingBox.GetComponentInChildren<TMP_Text>().text = miniGames[currentGameSelec].name;
        kingSpeakingBox.SetActive(true);
    }

    public void StartMiniGame()
    {
        miniGames[currentGameSelec].gameObject.GetComponent<MiniGames>().OnMiniGameStart.Invoke();
    }


}
