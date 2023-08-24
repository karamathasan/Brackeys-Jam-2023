using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Dialogue[] conversation;
    public Person person1;
    public Person person2;
    private int conversationIndex = 0;

    private bool speaking = false;


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
        if (Input.GetKeyDown("space") || Input.GetKeyDown("j") || Input.GetMouseButtonDown(1))
        {
            PlayNext();
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
        if (conversationIndex + 1< conversation.Length)
        {
            conversationIndex++;
            PlayDialogue();
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Type(Dialogue dialogue)
    {
        text.text = "";
        speaking = true;
        foreach (char letter in dialogue.line)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        speaking = false;
    }

}
