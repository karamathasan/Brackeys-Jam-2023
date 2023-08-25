using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public static List<string> Strutin_notes;
    public static List<string> Planet_notes;
    public static List<string> Didnduit_notes;
    public static List<string> Petezza_notes;
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
        else if (interviewIndex == 2)
        {
            if (!Petezza_notes.Contains(note))
            {
                Petezza_notes.Add(note);
            }
        }

        void Awake()
        {

        }
        void CompileLists()
        {
            string list = "";
            foreach(string line in Strutin_notes)
            {
                list += "\n";
            }
        }

    }
}
