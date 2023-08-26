using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notes : MonoBehaviour
{
    public static List<string> Strutin_notes = new List<string>();
    public static List<string> Planet_notes = new List<string>();
    public static List<string> Didnduit_notes = new List<string>();
    public static List<string> Petezza_notes = new List<string>();
    [SerializeField]
    public TextMeshProUGUI text;
    
    private void Awake()
    {
        CompileLists();
    }
    public static void Write(string note, int interviewIndex)
    {
        if (interviewIndex == 0)
        {
            if (!Strutin_notes.Contains(note))
            {
                Strutin_notes.Add(note);
            }
        }
        else if (interviewIndex == 1)
        {
            if (!Planet_notes.Contains(note))
            {
                Planet_notes.Add(note);
            }
        }
        else if (interviewIndex == 2)
        {
            if (!Didnduit_notes.Contains(note))
            {
                Didnduit_notes.Add(note);
            }
        }
        else if (interviewIndex == 3)
        {
            if (!Petezza_notes.Contains(note))
            {
                Petezza_notes.Add(note);
            }
        }
    }
    public void CompileLists()
    {
        string list = "";
        if (Strutin_notes.Count > 0) 
        {
            list += "Mr. Strutin";
            list += System.Environment.NewLine;
            foreach (string line in Strutin_notes)
            {
                list += line;
            }
        }

        if (Planet_notes.Count > 0) 
        {
            list += System.Environment.NewLine;
            list += System.Environment.NewLine;
            list += "Ms. Planet";
            list += System.Environment.NewLine;
            foreach (string line in Planet_notes)
            {
                list += line;
            }
        }

        if (Didnduit_notes.Count > 0)
        {
            list += System.Environment.NewLine;
            list += System.Environment.NewLine;
            list += "Mr. Didnduit";
            list += System.Environment.NewLine;
            foreach (string line in Didnduit_notes)
            {

                list += line;
            }
        }

        if (Petezza_notes.Count > 0)
        {
            list += System.Environment.NewLine;
            list += System.Environment.NewLine;
            list += "Mr. Petezza";
            list += System.Environment.NewLine;
            foreach (string line in Petezza_notes)
            {

                list += line;
            }
        }
        text.text = list;
           
    }

    public static void Clear()
    {
        Strutin_notes.Clear();
        Planet_notes.Clear();
        Didnduit_notes.Clear();
        Petezza_notes.Clear();
    }

    
}
