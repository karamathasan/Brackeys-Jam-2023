using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator fade;
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
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
}
