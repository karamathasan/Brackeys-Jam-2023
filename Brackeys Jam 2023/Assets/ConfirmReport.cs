using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmReport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transitioner;
    public GameObject[] questions;
    public int CalculateScore()
    {
        int score = 0;
        for(int i = 0; i < questions.Length; i++)
        {
            if (questions[i].GetComponent<DropdownQuestion>().correct)
            {
                score++;
            }
        }
        return score; 
    }
    public void NextScene()
    {
        int score = CalculateScore();
        if (score == 5)
        {
            transitioner.GetComponent<SceneTransitioner>().LoadNextScene(10);
            return;
        }
        else if(score > 1)
        {
            transitioner.GetComponent<SceneTransitioner>().LoadNextScene(9);
            return;
        }
        else
        {
            transitioner.GetComponent<SceneTransitioner>().LoadNextScene(8);
        }
    }
}
