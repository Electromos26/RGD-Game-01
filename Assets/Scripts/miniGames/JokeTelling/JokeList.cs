using System.Collections.Generic;
using UnityEngine;

public class JokeList : Singleton<JokeList>
{
    [SerializeField] private JokeContainer[] foodJokes;
    [SerializeField] private JokeContainer[] sportsJokes;
    [SerializeField] private JokeContainer[] musicJokes;
    [SerializeField] private JokeContainer[] animalJokes;
    [SerializeField] private JokeContainer[] farmingJokes;
    [SerializeField] private JokeContainer[] medievalJokes;

    private List<JokeContainer[]> list = new();

    void Awake() // load all jokes from resources folder
    {

        foodJokes = Resources.LoadAll<JokeContainer>("Jokes/Food");
        sportsJokes = Resources.LoadAll<JokeContainer>("Jokes/Sports");
        musicJokes = Resources.LoadAll<JokeContainer>("Jokes/Music");
        animalJokes = Resources.LoadAll<JokeContainer>("Jokes/Animals");
        farmingJokes = Resources.LoadAll<JokeContainer>("Jokes/Farming");
        medievalJokes = Resources.LoadAll<JokeContainer>("Jokes/Medieval");

        list.Add(foodJokes);
        list.Add(sportsJokes);
        list.Add(musicJokes);
        list.Add(animalJokes);
        list.Add(farmingJokes);
        list.Add(medievalJokes);


        //Debug.Log(sportsJokes.Length);
    }


    public JokeContainer GetJoke(JokeCatagory jokeCatagory)// call to get a joke from a specific catagory
    {
        switch (jokeCatagory)
        {
            case JokeCatagory.Food:
                return foodJokes[Random.Range(0, foodJokes.Length)];
            case JokeCatagory.Sports:
                return sportsJokes[Random.Range(0, sportsJokes.Length)];
            case JokeCatagory.Music:
                return musicJokes[Random.Range(0, musicJokes.Length)];
            case JokeCatagory.Animals:
                return animalJokes[Random.Range(0, animalJokes.Length)];
            case JokeCatagory.Farming:
                return farmingJokes[Random.Range(0, farmingJokes.Length)];
            case JokeCatagory.Medieval:
                return medievalJokes[Random.Range(0, medievalJokes.Length)];
            default:
                return null;
        }


    }
    public void RandomJokeSelection()
    {
        int randomJoke = Random.Range(0, list.Count);
        /*JokeCatagory cat1 = list[randomJoke][0].joke.jokeType;
        JokeCatagory cat2 = list[randomJoke][1].joke.jokeType;
        JokeCatagory cat3 = list[randomJoke][2].joke.jokeType;*/

        /*List<JokeContainer[]> tempList = list;
        for (int i = 0; i < 2; i++)
        {
            int randomCat = Random.Range(0, tempList.Count);

            JokeCatagory selectedGameObject = tempList[cat];
            MeshRenderer visible = selectedGameObject.GetComponent<MeshRenderer>();
            visible.enabled = true;
            tempObj.RemoveAt(randomGameObject);
        }*/
    }

}
