using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) quit();
    }

    public void play()
    {
        SceneManager.LoadScene(5);
    }
    public void options()
    {
        PlayerPrefs.SetInt("last", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }
    public void policy()
    {
        PlayerPrefs.SetInt("last", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(3);
    }
    public void quit()
    {
        Application.Quit();
    }

}
