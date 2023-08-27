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
    [SerializeField]
    private Animator noteAnim;
    [SerializeField]
    private float typeSpeed = 0.005f;
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
        if (Input.GetKeyDown("space") || Input.GetKeyDown("j") | Input.GetKeyDown("z") || Input.GetMouseButtonDown(0))
        {
            if (interviewIndex > 0)
            {
                noteAnim.ResetTrigger("TakeNote");
            }
            PlayNext();
        }
        if (conversation[conversationIndex].personNumber == 2 && (Input.GetKeyDown("z") || Input.GetMouseButtonDown(1)))
        {
            if(interviewIndex > 0)
            {
                Notes.Write(conversation[conversationIndex].line, interviewIndex);
                noteAnim.SetTrigger("TakeNote");
            }
            
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
        
        if (Input.GetKey(KeyCode.LeftShift ) && Application.isEditor == true)
        {
            //Skip(conversation[conversationIndex]);
            return;
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
            yield return new WaitForSeconds(typeSpeed);
        }
        speaking = false;
    }

    void Skip(Dialogue dialogue)
    {
        text.text = dialogue.line;
    }
    
    private void EndScene()
    {
        if (interviewIndex == -1)
        {
            transitioner.GetComponent<SceneTransitioner>().EndGame();
            return;
        }
        if (interviewIndex == 0 || interviewIndex == 50)
        {
            transitioner.GetComponent<SceneTransitioner>().LoadNextScene(SceneManager.GetActiveScene().buildIndex+1);
            return;
        }
        if (interviewIndex == 1)
        {
            InterviewSelection.interviewedStrutin = true;
        }
        else if (interviewIndex == 2)
        {
            InterviewSelection.interviewedPlanet = true;
        }
        else if (interviewIndex == 3)
        {
            InterviewSelection.interviewedDidnduit = true;
        }
        else if (interviewIndex == 4)
        {
            InterviewSelection.interviewedPetezza = true;
        }
        
        int count = SceneManager.sceneCountInBuildSettings;
        transitioner.GetComponent<SceneTransitioner>().LoadNextScene(count-1);

    }

}
