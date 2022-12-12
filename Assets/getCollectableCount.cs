using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class getCollectableCount : MonoBehaviour
{
    public TMP_Text tmp;
    private int coll;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<musicPlayer>().stopPlay();
        coll = persistence.instance.collected;
        tmp.text = "Beats collected: " + coll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
