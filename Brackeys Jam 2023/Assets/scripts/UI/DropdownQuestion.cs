using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    public string correctAnswer;
    public bool correct = false;
    [SerializeField]
    private TMP_Dropdown dropdown;
    public void UpdateStatus()
    {
        if (text.text == correctAnswer)
        {
            correct = true;
        }
        else correct = false;
    }
}
