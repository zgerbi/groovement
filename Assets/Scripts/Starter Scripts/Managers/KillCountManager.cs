using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KillCountManager : MonoBehaviour
{
    public TMP_Text killCountText;
    public int killScore = 0;


    // Start is called before the first frame update
       void Update()
    {
        killCountText.text = "Beatdowns:\t\t\t" + killScore.ToString();
    }
    
    public void AddKillCount(int value)
    {
        persistence.instance.killcount += 1;
        killScore += value;
        killCountText.text = killScore.ToString();
    }

    public void ResetScore()
    {
        persistence.instance.killcount = 0;

        killScore = 0;
    }



}
