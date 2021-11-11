using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private float TimeValue = 100;

    [SerializeField]
    private RawImage FullMiniMap = null;
    [SerializeField]
    private GameObject SmallMiniMap = null;

    private float StackTime = 0f;

    private bool minimapchange = true;

    private bool gameStart = true;


 


    private void Update()
    {
        StackTime += Time.deltaTime;
        float RemainTime = TimeValue - StackTime;
        TimeText.text = "남은 시간 : " + ((int)RemainTime).ToString("D3") + "초";
        remaintimeImage.fillAmount = RemainTime / TimeValue;
        Debug.Log(RemainTime / TimeValue);

        if (Input.GetMouseButtonDown(0)&& !player.GetComponent<Player>().GetPlayerDie()) 
        {
            minimapchange = !minimapchange;
        }


    }


    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        player.GetComponent<Player>().PlayerRevive();
        gameStart = true;
        Time.timeScale = 1;
    }


    public void PlayerDie()
    {
        if (player.GetComponent<Player>().GetPlayerDie())
        {
            GameOverUi.SetActive(true);
            gameStart = false;
            Time.timeScale = 0;
        }
    }

    public void MinimapChange1()
    {
        FullMiniMap.enabled = minimapchange;
        SmallMiniMap.SetActive(!minimapchange);
    }





}
