using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator fade;

    public void LoadNextScene(int buildIndex)
    {
        StartCoroutine(Transition(buildIndex));
    }
    IEnumerator Transition(int buildIndex)
    {
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(buildIndex);
    }

    public void EndGame()
    {
        StartCoroutine(EndTransition());
    }
    IEnumerator EndTransition()
    {
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
