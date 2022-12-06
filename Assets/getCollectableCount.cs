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
        coll = persistence.instance.collected;
        tmp.text = "Beats collected: " + coll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
