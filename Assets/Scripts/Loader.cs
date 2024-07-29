using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] ProgressBar progressBar;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {   
        SoundManager.MusicVolume = PlayerPrefs.GetInt("music", 1);
        SoundManager.SoundVolume = PlayerPrefs.GetInt("sounds", 1);
        progressBar.BarValue = 0;
        Music.PlayLoopingMusicManaged(1.0f, 1.0f, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad>=time)
        {
            time += 0.03f;
            progressBar.BarValue++;
        }
        if(progressBar.BarValue>=100)
        {
            int needPolicy = PlayerPrefs.GetInt("startScene", 1);
            SceneManager.LoadScene(needPolicy);
        }
    }
}
