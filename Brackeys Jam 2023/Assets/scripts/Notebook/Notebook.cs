using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite[] notebookTabs;
    private SpriteRenderer sr;
    public int currentTab = 1;
    [SerializeField]
    public GameObject[] tabContent;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        OpenTab(currentTab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentTab -= 1;
            if(currentTab < 1)
            {
                currentTab = 4;
            }
            OpenTab(currentTab);
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentTab += 1;
            if (currentTab > 4)
            {
                currentTab = 1;
            }
            OpenTab(currentTab);
        }
    }

    public void OpenTab(int tabNum)
    {
        currentTab = tabNum;
        sr.sprite = notebookTabs[tabNum - 1];
        for (int i = 1; i < 5; i++)
        {
            if (tabNum != i)
            {
                tabContent[i - 1].SetActive(false);
            }else tabContent[i - 1].SetActive(true);

        } 
    }
}
