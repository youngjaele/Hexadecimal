using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBtn : MonoBehaviour
{
    public AudioClip sBtn;
    public AudioSource startAudio;
    // Start is called before the first frame update
    void Start()
    {
        initGame();

        void initGame()
        {
            Time.timeScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startSound()
    {
        startAudio.PlayOneShot(sBtn);
        Invoke("startGame", 0.5f);
    }
    void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
