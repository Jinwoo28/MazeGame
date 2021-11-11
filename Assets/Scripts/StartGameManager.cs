using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Subscription1 = null;

    [SerializeField]
    private GameObject Subscription2 = null;

    [SerializeField]
    private GameObject Subscription = null;

    [SerializeField]
    private GameObject Level = null;

    private void Update()
    {

    }

    public void ChoiceLevel()
    {
        Level.SetActive(true);
    }

    public void ExitLevel()
    {
        Level.SetActive(false);
    }

    public void Subscription_()
    {
        Subscription.SetActive(true);
    }
public void Subscription_1()
    {
        Subscription1.SetActive(true);
        Subscription2.SetActive(false);
    }
    public void Subscription_2()
    {
        Subscription1.SetActive(false);
        Subscription2.SetActive(true);
    }

    public void SubscriptionExit()
    {
        Subscription1.SetActive(true);
        Subscription2.SetActive(false);
        Subscription.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }



}


