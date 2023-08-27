using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Notes.Clear();
        InterviewSelection.Clear();
        Application.targetFrameRate = 75;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);// load the games first scene
    }
}
