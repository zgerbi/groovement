using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code inspired by Denvery on unity forums:
// https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html

public class musicPlayer : MonoBehaviour
{
    private AudioSource music;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<AudioSource>();
    }

    public void startPlay()
    {
        if (music.isPlaying)
            return;
        music.Play();
    }

    public void stopPlay()
    {
        music.Stop();
    }

}
