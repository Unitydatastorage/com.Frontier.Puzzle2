using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private float time = 60;
    private int score = 0;

    [SerializeField] Text scoreText;
    [SerializeField] Item[] items;
    private List<int> colors = new List<int>();
    int count = 10;
    [SerializeField] AudioSource lose;
    [SerializeField] AudioSource win;

    private int first = -1, last = -1;

    // Start is called before the first frame update
    void Start()
    {
        List<int> color = new List<int>();
        while(color.Count!=items.Length/2) {
            int tmp = Random.Range(0, 8);
            if (!color.Contains(tmp)) color.Add(tmp);
        }
        while(color.Count>0)
        {
            int tmp = color[0];
            color.RemoveAt(0);
            colors.Add(tmp);
            colors.Add(tmp);
        }
        for(int i =0; i < items.Length; i++)
        {
            items[i].game = this;
            items[i].index = i;
            int d = Random.Range(0, colors.Count);
            items[i].Color = colors[d];
            colors.RemoveAt(d);
        }

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Escape))
        {
            goBack();  
        }     
        time -= Time.deltaTime;
        if(time < 0 || count<=0)
        {
            int maxLevel = PlayerPrefs.GetInt("current", 0);
            int level = PlayerPrefs.GetInt("level", 0);
            if(count==0) maxLevel = Mathf.Max(maxLevel, level+1);
            maxLevel = Mathf.Min(maxLevel, 19);
            int stars = 0;
            if(count==0) { 
                stars = 1;
                if (time >= 45) stars = 3;
                else if (time >= 20) stars = 2;
            }
            PlayerPrefs.SetInt(level.ToString(), stars);
            stars = Mathf.Max(PlayerPrefs.GetInt("stars" + level, 0), stars);
            PlayerPrefs.SetInt("stars"+level, stars);
            PlayerPrefs.SetInt("current",maxLevel);
            PlayerPrefs.SetInt("time", (int)time);
            PlayerPrefs.SetInt("score", score);
            //PlayerPrefs.SetInt("win",count>0 ? 0 : 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(7);
        }
        else
        {
            scoreText.text = score.ToString();
           // timer.text = time>=60 ?  string.Format("{0:00}:{1:00}", Mathf.FloorToInt(time / 60), Mathf.FloorToInt(time % 60)): string.Format("{0:00}:{1:00}", Mathf.FloorToInt(time / 60), Mathf.FloorToInt(time % 60));
        }

    }

    public void toggleItem(int ind)
    {
        print(first + " " + last);
        Item item = items[ind];
        if(item.open)
        {
            if(first == -1) {
                first = ind;
            } else
            {
                if(last == -1)
                {
                    last = ind;
                    if (items[first].Color == items[last].Color)
                    {
                        items[first].cantChange = true;
                        items[last].cantChange = true;
                        first = -1;
                        last = -1;
                        score += (int)time * 2;
                        count -= 2;
                        win.PlayOneShotSoundManaged(win.clip);
                    } else
                    {
                        items[first].toggle(false);
                        items[last].toggle(false);
                        first = -1;
                        last = -1;
                        lose.PlayOneShotSoundManaged(lose.clip);
                    }
                } 
            }
        } else
        {
            if(first!=-1)
            {
                first = -1;
            }
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene(5);
    }

    public void goSettings()
    {
        PlayerPrefs.SetInt("last", 6);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }
}
