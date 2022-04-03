using UnityEngine;
using System.Collections;

public class TextTimer : aaaa
{
    public float time = 5; //Seconds to read the text

    void Start()
    {
        Destroy(gameObject, time);
    }
}