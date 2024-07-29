using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] Text textMeshProUGUI;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {   
        int level = PlayerPrefs.GetInt("level", 0) + 1;
        int starsCount = PlayerPrefs.GetInt((level-1).ToString(), -1);
        textMeshProUGUI.text = starsCount > -1 ? "LEVEL "+level+"\nCOMPLETE" : "LOSE";
        int current = PlayerPrefs.GetInt("current", 0);
        button.SetActive(level<=current);
        int score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBack()
    {
        SceneManager.LoadScene(2);
    }

    public void goNext()
    {
        int level = PlayerPrefs.GetInt("level", 0) + 1;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }
}
