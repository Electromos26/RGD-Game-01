using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "joke", menuName = "ScriptableObjects/CreateJokeContainer")]

public class JokeContainer : ScriptableObject
{
    public JokeData joke;
}
[System.Serializable]
public struct JokeData
{
    public JokeCatagory jokeType;
    [TextArea]
    public string jokePhrase;
    public string correctAnswer;
    public string[] wrongAnswer;
    public string firstPart;
    public string lastPart;

}