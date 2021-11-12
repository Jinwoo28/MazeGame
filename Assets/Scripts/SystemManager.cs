using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public static SystemManager instance = null;

    private int Level = 0;

    private float Score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public int GetGameLevel_()
    {
        return Level;
    }

    public void GameLeveChoicel_(int level_)
    {
        Level = level_;
        SceneManager.LoadScene(1);
    }

public void EndGame()
    {
        Application.Quit();
    }

    public void GameClear()
    {
        SceneManager.LoadScene(2);
    }

    public void GameReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }


    public void Debugcheck()
    {
        Debug.Log("Check");
    }

    public void CountScore(float remaintime_)
    {
        Score = Level * remaintime_;
    }

    public float GetCurrentScore()
    {
        return Score;
    }



    

}
