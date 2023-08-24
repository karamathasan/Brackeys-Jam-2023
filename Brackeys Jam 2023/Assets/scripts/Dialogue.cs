using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    public Sprite sprite;
    public string line;
    public int personNumber;
}
