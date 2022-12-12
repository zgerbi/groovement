using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetKillcount : MonoBehaviour
{
    public TMP_Text tmp;
    private int kills;
    // Start is called before the first frame update
    void Start()
    {
        kills = persistence.instance.killcount;
        tmp.text = "Beatdowns given: " + kills;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
