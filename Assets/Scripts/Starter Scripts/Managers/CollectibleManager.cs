using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectibleManager : MonoBehaviour
{
    public static int collected;
    [SerializeField] private TMP_Text collectibles;
    [SerializeField] public PlayerHealth playerhealth;

    //[SerializeField] private int collected;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: change back to 0 after debug
        persistence.instance.collected = 49;
        collected = 49;
        persistence.instance.level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        collectibles.text = "Beats:\t\t\t\t\t\t\t\t" + collected + "/50";

        if (collected >= 50)
        {
            levelUp();
        }
    }

    public void Collected(int value)
    {
        collected += value;
        persistence.instance.collected += value;
    }

    private void levelUp()
    {
        collected = 0;
        playerhealth.IncreaseHealth(100);
        persistence.instance.level++;
        //Debug.Log("Level up to: " + persistence.instance.level);
    }
}
