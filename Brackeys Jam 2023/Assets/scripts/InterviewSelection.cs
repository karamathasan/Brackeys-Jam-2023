using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InterviewSelection : MonoBehaviour
{
    //[SerializeField]
    public static bool interviewedStrutin = false;
    //[SerializeField]
    public static bool interviewedPlanet = false;
    //[SerializeField]
    public static bool interviewedDidnduit = false;
    //[SerializeField]
    public static bool interviewedPetezza = false;

    public Button interviewStrutin;
    public Button interviewPlanet;
    public Button interviewDidnduit;
    public Button interviewPetezza;
    // Start is called before the first frame update

    void Start()
    {
        if (interviewedStrutin)
        {
            interviewPlanet.interactable = true;
        }
        else interviewPlanet.interactable = false;

        if (interviewedPlanet)
        {
            interviewDidnduit.interactable = true;
        }
        else interviewDidnduit.interactable = false;

        if (interviewedDidnduit)
        {
            interviewPetezza.interactable = true;
        }
        else interviewPetezza.interactable = false;
        interviewStrutin.interactable = true;
    }

    public void NextScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
