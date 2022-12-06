using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectibleManager : MonoBehaviour
{
    //public static int collected;
    [SerializeField] private TMP_Text collectibles;
    [SerializeField] private int collected;

    // Start is called before the first frame update
    void Start()
    {
        persistence.instance.collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        collectibles.text = "Beats:\t\t\t\t\t\t\t\t" + persistence.instance.collected;
    }

    public void Collected(int value)
    {
        persistence.instance.collected += value;
    }

}
