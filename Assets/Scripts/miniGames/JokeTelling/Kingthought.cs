using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingthought : Singleton<Kingthought>
{
    public JokeIcon[] jokeIcon;
}

[Serializable]
public struct JokeIcon
{
    public JokeCatagory jokeType;
    public Sprite image;
}