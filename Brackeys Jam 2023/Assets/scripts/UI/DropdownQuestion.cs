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
        correct = isCorrect();
    }

    public bool isCorrect()
    {
        if (text.text == correctAnswer)
        {
            Debug.Log("thats right");
            return true;
        }
        else return false;
    }
}
