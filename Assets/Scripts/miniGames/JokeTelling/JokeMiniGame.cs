using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JokeMiniGame : Singleton<JokeMiniGame>
{
    [SerializeField] private GameObject jokeCategories;

    [SerializeField] TMP_Text cat1Text;
    [SerializeField] TMP_Text cat2Text;
    [SerializeField] TMP_Text cat3Text;

    string cat1;
    string cat2;
    string cat3;

    private JokeCatagory[] tempCat = new JokeCatagory[3];

    private JokeCatagory correctCatagory;

    public void Show3Catagory(JokeCatagory[] catagories)
    {
        cat1 = catagories[0].ToString();
        cat2 = catagories[1].ToString();
        cat3 = catagories[2].ToString();

        tempCat = catagories;


        cat1Text.text = cat1;
        cat2Text.text = cat2;
        cat3Text.text = cat3;

        jokeCategories.SetActive(true);

        SelectRightCat(tempCat);

    }

    public void CatagoryChosen(TMP_Text chosenCategory)
    {
        jokeCategories.SetActive(false);

        for (int i = 0; i < tempCat.Length; i++)
        {
            if (tempCat[i].ToString() == chosenCategory.text)
            {
                DisplayJokeManager.Instance.DisplayJoke(tempCat[i]);
                if (chosenCategory.text == correctCatagory.ToString())
                {
                    DisplayJokeManager.Instance.points++;
                }
                else
                {
                    DisplayJokeManager.Instance.points--;

                }
            }
        }

    }

    public void PunishAndReturn()
    {
        KingHappinessManager.Instance.AddHappiness(-2);
        TransitionManager.Instance.SetState(TransitionManager.State.KingReacting);
    }

    private void SelectRightCat(JokeCatagory[] catagories)
    {
        int randomIndex = Random.Range(0, catagories.Length);
        correctCatagory = catagories[randomIndex];
        KingsThought.Instance.showThought(correctCatagory);
    }


}
