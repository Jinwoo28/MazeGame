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

    private float TimeValue = 60;

    [SerializeField]
    private RawImage FullMiniMap = null;
    [SerializeField]
    private GameObject SmallMiniMap = null;

    private float StackTime = 0f;

    private bool minimapchange = true;

    private bool gameStart = true;


 


    private void Update()
    {
        float remainTime = player.GetComponent<Player>().RemainTime_();
        TimeText.text = "남은 시간 : " + ((int)remainTime).ToString("D3") + "초";
        remaintimeImage.fillAmount = remainTime / TimeValue;
       
    }




    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        gameStart = true;
        Time.timeScale = 1;

    }


    public void PlayerDie()
    {

            GameOverUi.SetActive(true);
            gameStart = false;
            Time.timeScale = 0;

    }

    public void MinimapChange1()
    {
        FullMiniMap.enabled = minimapchange;
        SmallMiniMap.SetActive(!minimapchange);
    }





}
