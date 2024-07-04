using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPageScript : MonoBehaviour
{
    private Slider sliderLoadingBar;
    private TextMeshProUGUI textLoadingBar;
    void Start()
    {
        GameObject textObject = GameObject.Find("Text_LoadingBar");
        textLoadingBar = textObject.GetComponent<TextMeshProUGUI>();

        GameObject loadingBar = GameObject.Find("Slider_LoadingBar");
        sliderLoadingBar = loadingBar.GetComponent<Slider>();

        //int levelToLoad = GameManager.currentLevel;
        //StartCoroutine(LoadLevelAsync($"Level_{levelToLoad}"));
    }

    void Update()
    {
        if (sliderLoadingBar.value < 1)
        {
            sliderLoadingBar.value += 0.001f;
            textLoadingBar.text = Math.Floor(sliderLoadingBar.value * 100).ToString() + "%";
        }
        else
        {
            SceneManager.LoadScene($"Level_{GameManager.currentLevel}");
        }
    }


    //Correct version for prod, but too fast for small levels
    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            sliderLoadingBar.value = progress;
            textLoadingBar.text = Math.Floor(sliderLoadingBar.value * 100).ToString() + "%";

            if (progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
