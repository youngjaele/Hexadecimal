using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip bgmusic;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource.clip = bgmusic;
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
