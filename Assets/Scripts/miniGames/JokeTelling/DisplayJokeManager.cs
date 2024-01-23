using UnityEngine;
using TMPro;
using System.Linq;

public class DisplayJokeManager : Singleton<DisplayJokeManager>

{
    //Jokes
    [SerializeField] private GameObject jokeChoices;

    #region Text Containers
    [SerializeField] TMP_Text jokePhrasetxt;

    [SerializeField] TMP_Text Answer1;
    [SerializeField] TMP_Text Answer2;
    [SerializeField] TMP_Text Answer3;
    [SerializeField] TMP_Text Answer4;
    #endregion

    private string jokePhrase;
    private string correctAnswer;
    private string[] wrongAnswer;
    private string firstPart;
    private string lastPart;

    private string[] wrongChoices;
    private string[] Choices;


    private void Awake()
    {
        //DisplayJoke();
    }

    void SelectAnswers(JokeContainer jokeContainer)
    {
        wrongAnswer = jokeContainer.joke.wrongAnswer;
        wrongChoices = new string[3];

        for (int i = 0; i < wrongChoices.Length; i++)
        {
            string textCheck = wrongAnswer[Random.Range(0, wrongAnswer.Length)];
            if (wrongChoices.Contains(textCheck))
            {
                i--;
            }
            else
            {
                wrongChoices[i] = textCheck;
            }

        }

        Choices = new string[4];
        for (int i = 0; i < wrongChoices.Length; i++)
        {
            int choicesInt = Random.Range(0, Choices.Length);
            if (Choices[choicesInt] == null)
            {
                Choices[choicesInt] = wrongChoices[i];
            }
            else
            {
                i--;
            }

        }

        for (int i = 0; i < Choices.Length; i++)
        {
            if (Choices[i] == null)
            {
                Choices[i] = jokeContainer.joke.correctAnswer;
                correctAnswer = Choices[i];
            }
        }

    }

    public void DisplayJoke(JokeCatagory jokeCatagory)
    {
        JokeContainer jokeContainer = JokeList.Instance.GetJoke(jokeCatagory);

        jokePhrase = jokeContainer.joke.jokePhrase;

        correctAnswer = jokeContainer.joke.correctAnswer;
        wrongAnswer = jokeContainer.joke.wrongAnswer;

        firstPart = jokeContainer.joke.firstPart;
        lastPart = jokeContainer.joke.lastPart;

        jokePhrasetxt.text = jokePhrase;

        SelectAnswers(jokeContainer);
        
        Answer1.text = Choices[0];
        Answer2.text = Choices[1];
        Answer3.text = Choices[2];
        Answer4.text = Choices[3];

        jokeChoices.SetActive(true);

    }

    public void CheckAnswer(TMP_Text buttonText)
    {
        if (buttonText.text == correctAnswer)
        {
            Debug.Log("Correct");
            //We need to do the points logic
        }
        else
        {
            Debug.Log("Wrong");
        }

        //Shoot Event for new message popup with the answer the player gave
    }

}
