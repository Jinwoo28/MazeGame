using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{

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
public void ExitSubscription()
    {
        Subscription.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }



}


