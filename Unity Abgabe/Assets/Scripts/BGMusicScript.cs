using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    public AudioSource bgMusic;

    void Start()
    {
        bgMusic.Play();
    }
    void Update()
    {
        if (Time.timeScale <= 0)
        {
            bgMusic.Stop();
        }
    }
}
