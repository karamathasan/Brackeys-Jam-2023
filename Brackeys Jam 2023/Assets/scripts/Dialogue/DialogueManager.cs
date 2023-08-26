using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] conversation;
    public TextMeshProUGUI text;
    public Person person1;
    public Person person2;
    private int conversationIndex = 0;
    [SerializeField]
    private int interviewIndex = 0;
    private bool speaking = false;
    [SerializeField]
    private GameObject transitioner;
    // Start is called before the first frame update
    void Start()
    {
        PlayDialogue();
    }
    void Update()
    {
        if (speaking)
        {
            return;
        }
        if (Input.GetKeyDown("space") || Input.GetKeyDown("j") || Input.GetMouseButtonDown(0))
        {
            PlayNext();
        }
        if (conversation[conversationIndex].personNumber == 2 && (Input.GetKeyDown("z") || Input.GetMouseButtonDown(1)))
        {
            //Debug.Log("notes taken");
            Notes.Write(conversation[conversationIndex].line, interviewIndex);
        }
    }


    private void PlayDialogue()
    {
        if (conversation[conversationIndex].personNumber == 1)
        {
            person1.SetSprite(conversation[conversationIndex].sprite);
            person1.Flipped(true);
            person1.Darkened(false);
            person2.Darkened(true);
        }
        if (conversation[conversationIndex].personNumber == 2)
        {
            person2.SetSprite(conversation[conversationIndex].sprite);
            person2.Darkened(false);
            person1.Darkened(true);
        }
        
        StartCoroutine(Type(conversation[conversationIndex]));
    }
    private void PlayNext()
    {
        if (conversationIndex + 1 < conversation.Length)
        {
            conversationIndex++;
            PlayDialogue();
        }
        else EndScene();
    }

    IEnumerator Type(Dialogue dialogue)
    {
        text.text = "";
        speaking = true;
        foreach (char letter in dialogue.line)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.015f);
        }
        speaking = false;
    }
    
    private void EndScene()
    {
        if (interviewIndex == 0)
        {
            InterviewSelection.interviewedStrutin = true;
        }
        else if (interviewIndex == 1)
        {
            InterviewSelection.interviewedPlanet = true;
        }
        else if (interviewIndex == 2)
        {
            InterviewSelection.interviewedDidnduit = true;
        }
        else if (interviewIndex == 3)
        {
            InterviewSelection.interviewedPetezza = true;
        }
        int count = SceneManager.sceneCountInBuildSettings;
        transitioner.GetComponent<SceneTransitioner>().LoadNextScene(count-1);

    }

}
