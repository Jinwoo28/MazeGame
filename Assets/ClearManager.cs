using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    [SerializeField]
    private InputField IF = null;
    [SerializeField]
    private Text BestScore = null;

    [SerializeField]
    private GameObject ScorePopup = null;


    private bool ScoreChange = false;

    float CurrentScore = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      CurrentScore =  SystemManager.instance.GetCurrentScore();
       
      
    }

    public void GetBestScore()
    {
        float BestScore_ = PlayerPrefs.GetFloat("BestScore");

        if (CurrentScore > BestScore_)
        {
            PlayerPrefs.SetFloat("BestScore", CurrentScore);
            BestScore.text = IF.text + "님 최고기록 \n" + CurrentScore;
        }

        else
        {
            BestScore.text = "현재 최고기록 : " + BestScore_ +"\n" + IF.text + "님 최고기록 : " + CurrentScore ;          
        }

    }

    

    public void Startscene()
    {
        SystemManager.instance.StartScene();
    }

    public void EndGame()
    {
        SystemManager.instance.EndGame();
    }

}
