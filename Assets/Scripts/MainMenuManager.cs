using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton, chooseStageButton, exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(StartPlay);
        chooseStageButton.onClick.AddListener(ChooseStage);
        exitButton.onClick.AddListener(ExitFunction);
    }

    private void StartPlay()
    {
        GameManager.currentLevel = 1;
        SceneManager.LoadScene("LoadingPage");
    }

    private void ChooseStage()
    {

    }

    private void ExitFunction()
    {
        Application.Quit();
    }
}
