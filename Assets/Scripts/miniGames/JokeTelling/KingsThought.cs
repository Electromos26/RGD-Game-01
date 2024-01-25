using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class KingsThought : Singleton<KingsThought>
{
    [SerializeField] private CatagoryContainer[] categoryArray;
    [SerializeField] private Image image;
    [SerializeField] private GameObject thought;

    Dictionary<JokeCatagory, Sprite> myDict = new Dictionary<JokeCatagory, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < categoryArray.Length; i++)
        {
            myDict.Add(categoryArray[i].category.jokeType, categoryArray[i].category.sprite);
        }
    }

    public void showThought(JokeCatagory correctCategory)
    {
        thought.SetActive(true);
        image.sprite = myDict[correctCategory];
    }

}
