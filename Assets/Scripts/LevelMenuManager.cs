using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuManager : MonoBehaviour
{
    public Button woodsBtn, islandsBtn, cityBtn, backToMainMenuBtn;

    private void Start()
    {
        woodsBtn.onClick.AddListener(WoodsBtnClick);
        islandsBtn.onClick.AddListener(IslandBtnClick);
        cityBtn.onClick.AddListener(CityBtnClick);
        backToMainMenuBtn.onClick.AddListener(BackToMainMenuBtnClick);
    }

    private void WoodsBtnClick()
    {
        GameManager.currentScene = GameManager.scenes["Woods"] ?? GameManager.scenes["MainMenu"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    private void IslandBtnClick()
    {
        GameManager.currentScene = GameManager.scenes["Islands"] ?? GameManager.scenes["MainMenu"];
        SceneManager.LoadScene("LoadingPage");
    }

    private void CityBtnClick()
    {
        GameManager.currentScene = GameManager.scenes["City"] ?? GameManager.scenes["MainMenu"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    private void BackToMainMenuBtnClick()
    {
        GameManager.currentScene = GameManager.scenes["MainMenu"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }
}
