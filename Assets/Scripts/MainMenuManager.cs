using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton, chooseStageButton, exitButton, shopButton;
    private DroneManager droneManager;

    private void Start()
    {
        playButton.onClick.AddListener(StartPlay);
        chooseStageButton.onClick.AddListener(ChooseStage);
        exitButton.onClick.AddListener(ExitFunction);
        shopButton.onClick.AddListener(OpenShop);

        droneManager = DroneManager.instance;
    }

    private void OpenShop()
    {
        GameManager.currentScene = GameManager.scenes["Shop"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    private void StartPlay()
    {
        GameManager.currentScene = GameManager.scenes["Woods"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    private void ChooseStage()
    {
        GameManager.currentScene = GameManager.scenes["SelectLevel"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    private void ExitFunction()
    {
        Application.Quit();
    }
}
