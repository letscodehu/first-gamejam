using System;
using UnityEngine;

[Serializable]
public class Dialogue
{

    public String name;
    [TextArea(3,10)]
    public String[] sentences;

}
