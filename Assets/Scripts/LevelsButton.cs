using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsButton : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] Sprite[] stars;
    [SerializeField] Image star;
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = (level + 1).ToString();
        Button button = GetComponent<Button>();
        int current = PlayerPrefs.GetInt("current", 0);
        button.interactable = (current >= level);
        int count = PlayerPrefs.GetInt("stars" + level, 0);
        //Image star = GetComponentInChildren<Image>();
        star.sprite = stars[Mathf.Min(count,stars.Length-1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void play()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }
}
