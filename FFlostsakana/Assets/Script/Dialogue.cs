using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public List<Sprite> images;

    [TextArea(1, 1)]
    public string[] names;

    [TextArea(3, 10)]
    public string[] sentences;


}
