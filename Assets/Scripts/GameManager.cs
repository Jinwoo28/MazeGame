using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverUi = null;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private Text TimeText = null;

    [SerializeField]
    private Image remaintimeImage = null;

    private float TimeValue = 60;

    [SerializeField]
    private GameObject SmallMiniMap = null;

    private float StackTime = 0f;

    private bool minimapchange = true;

    private bool gameStart = true;

    [SerializeField]
    private GameObject PopupManu = null;

    float remainTime = 0;

    private bool checkGameStart = false;


    [SerializeField]
    private Text GetCurrentScore = null;
    private void Awake()
    {
        Time.timeScale = 1;
    }


    private void Update()
    {
        remainTime = player.GetComponent<Player>().RemainTime_();
        TimeText.text = "남은 시간 : " + ((int)remainTime).ToString("D3") + "초";
        remaintimeImage.fillAmount = remainTime / TimeValue;

        GetCurrentScore.text = "현재 점수 : " + ((int)SystemManager.instance.GetCurrentScore()).ToString();
        PlayerDie();
        checkGameStart = true;

        SystemManager.instance.CountScore(remainTime);

    }


    public void PlayerDie()
    {
        if (remainTime <= 0&&checkGameStart)
        {
            GameOverUi.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartGameScene()
    {
        SystemManager.instance.StartScene();
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SystemManager.instance.GameReStart();
    }

    public void Exitgame()
    {
        SystemManager.instance.EndGame();
    }

    public void ToggleOnOff(bool value)
    {
        if (value) SmallMiniMap.SetActive(true);

        else SmallMiniMap.SetActive(false);
    }

    public void PopupOpen()
    {
        PopupManu.SetActive(true);
    }

    public void PopupClose()
    {
        PopupManu.SetActive(false);
    }


}
