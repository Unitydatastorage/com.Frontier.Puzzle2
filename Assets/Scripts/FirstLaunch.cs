using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstLaunch : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void accept()
    {
        PlayerPrefs.SetInt("startScene", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    public void openPolicy()
    {
        PlayerPrefs.SetInt("last", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }
}
