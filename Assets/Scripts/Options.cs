using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    [SerializeField] UISwitcher.UISwitcher sound;
    [SerializeField] UISwitcher.UISwitcher music;

    // Start is called before the first frame update
    void Start()
    {
        int sounds1 = PlayerPrefs.GetInt("sounds", 1);
        int music1 = PlayerPrefs.GetInt("music", 1);
        sound.isOn = sounds1 == 1;
        music.isOn = music1 == 1;
        sound.OnValueChanged += changeS;
        music.OnValueChanged += changeM;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeS(bool change)
    {
        int sounds1 = PlayerPrefs.GetInt("sounds", 1);
        sounds1++;
        sounds1 %= 2;
        SoundManager.SoundVolume = sounds1;
        PlayerPrefs.SetInt("sounds", sounds1);
        PlayerPrefs.Save();

    }
    public void changeM(bool change)
    {
        int music1 = PlayerPrefs.GetInt("music", 1);
        music1++;
        music1 %= 2;
        SoundManager.MusicVolume = music1;
        PlayerPrefs.SetInt("music", music1);
        PlayerPrefs.Save();
    }


    public void goBack()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("last", 2));
    }
}
