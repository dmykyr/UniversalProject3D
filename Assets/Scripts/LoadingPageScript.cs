using System;
using TMPro;
using UnityEngine;
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
    }

    void Update()
    {
        if (sliderLoadingBar.value <= 100)
        {
            sliderLoadingBar.value += 0.001f;
            
            textLoadingBar.text = Math.Floor(sliderLoadingBar.value * 100).ToString() + "%";
        }
    }
}
