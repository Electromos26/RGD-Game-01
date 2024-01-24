using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "category", menuName = "ScriptableObjects/CreateCategoryContainer")]

public class CatagoryContainer : ScriptableObject
{
    public CatagoryData category;
}
[System.Serializable]
public struct CatagoryData
{
    public JokeCatagory jokeType;
    public Sprite sprite;
}

public enum JokeCatagory
{
    Food,
    Sports,
    Music,
    Animals,
    Farming,
    Medieval
}