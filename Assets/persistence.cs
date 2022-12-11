using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class persistence : MonoBehaviour
{
    public static persistence instance;
    public int killcount, collected, level;
    public GameSceneManager sm;
    public TMP_Text col;
    private bool tutorialDone = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(gameObject);
            return;
        }
        ///TODO: Change this to a level check or a higher kill check
        if (killcount >= 500)
        {
            sm.LoadScene(5);
        }
    }

    private void Awake()
    {
       
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void finishedTutorial()
    {
        tutorialDone = true;
    }
}
