using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]
    public int personNum;
    [SerializeField]
    private SpriteRenderer sr;
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    public void SetSprite(Sprite psprite)
    {
        sr.sprite = psprite;
    }

    public void Darkened(bool darkened)
    {
        if (darkened)
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            sr.color = new Color(1f, 1f, 1f);
        }
    }
    public void Flipped(bool flipped)
    {
        Transform transform = gameObject.GetComponent<Transform>();
        if (flipped)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else transform.localScale = new Vector3(1, 1, 1);
    }
}
