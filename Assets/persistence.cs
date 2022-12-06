using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class persistence : MonoBehaviour
{
    public static persistence instance;
    public int killcount, collected;
    public GameSceneManager sm;
    public TMP_Text col;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(gameObject);
            return;
        }
        if (killcount >= 50)
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
}
