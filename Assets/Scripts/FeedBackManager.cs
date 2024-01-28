using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackManager : Singleton<FeedBackManager>
{
    [SerializeField]
    private GameObject hat;
    [SerializeField]
    private GameObject holder;

    private List<GameObject> hatImages;

    [SerializeField] private Color correctColor;
    [SerializeField] private Color wrongColor;

    private int currentHat = 0;



    public void AddHats(int numberOfHats)
    {
        holder.SetActive(true);
        hatImages = new List<GameObject>();
        for (int i = 0; i < numberOfHats; i++)
        {
            hatImages.Add(Instantiate(hat, holder.transform));
        }
    }

    public void ChangeColor(bool check)
    {
        if (check)
        {
            hatImages[currentHat].GetComponent<Image>().color = correctColor;
        }
        else
        {
            hatImages[currentHat].GetComponent<Image>().color = wrongColor;
        }

        currentHat++;
    }

    public void ClearHats()
    {
        currentHat = 0;
        foreach (GameObject hat in hatImages)
        {
            Destroy(hat);
        }
        Debug.Log(hatImages.Count);
    }

}
