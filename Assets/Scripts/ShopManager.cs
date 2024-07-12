using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] droneCards;
    public TextMeshProUGUI coinsAmountText;
    public Button backToMainMenuBtn;

    private GameManager gameManager;
    private Dictionary<string, string> droneCardsToNames = new()
    {
        { "Drone1", "Drone Black"},
        { "Drone2", "Drone Blue"},
        { "Drone3", "Drone Orange"},
        { "Drone4", "Drone Red"},
    };

    public void Start()
    {
        backToMainMenuBtn.onClick.AddListener(BackToMainMenuBtnClick);

        InitializeUIElements();

        gameManager = GameManager.instance;
        if (gameManager != null)
        {
            int coinsAmount = gameManager.CoinsAmount;
            coinsAmountText.text = coinsAmount.ToString();
            CheckUnavailableCards(coinsAmount);
        }
    }

    private void BackToMainMenuBtnClick()
    {
        if (gameManager != null)
        {
            gameManager.SaveCurrentResourceValues();
        }

        GameManager.currentScene = GameManager.scenes["MainMenu"];
        SceneManager.LoadScene(GameManager.scenes["Loading"]);
    }

    public void InitializeUIElements()
    {
        foreach (var droneCard in droneCards)
        {
            SetCardBlock(droneCard, false);
            Button droneCardButton = droneCard.GetComponentInChildren<Button>();
            droneCardButton.onClick.AddListener(DronePurchaseBtnClicked);
        }
    }

    private void DronePurchaseBtnClicked()
    {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        
        Transform parentTransform = clickedButton.transform.parent;
        GameObject parentGameObject = parentTransform.gameObject;
        string selectedDroneName = parentGameObject.name;


        TextMeshProUGUI priceText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
        int dronePrice = int.Parse(priceText.text);

        DroneManager droneManager = DroneManager.instance;
        if (gameManager != null && droneManager != null)
        {
            int currentCoins = gameManager.CoinsAmount;

            if (currentCoins >= dronePrice)
            {

                gameManager.CoinsAmount -= dronePrice;
                droneManager.ChangeCurrentDroneSkin(droneManager.dronePrefabsKeys[droneCardsToNames[selectedDroneName]]);

                coinsAmountText.text = gameManager.CoinsAmount.ToString();

                CheckUnavailableCards(gameManager.CoinsAmount);
            }
        }
    }

    public void CheckUnavailableCards(int coinsAmount)
    {
        foreach (var droneCard in droneCards)
        {
            Button droneCardButton = droneCard.GetComponentInChildren<Button>();
            TextMeshProUGUI dronePriceText = droneCardButton.GetComponentInChildren<TextMeshProUGUI>();
            int dronePrice = int.Parse(dronePriceText.text);

            if (dronePrice > coinsAmount)
            {
                SetCardBlock(droneCard, true);
            }
        }
    }
    public void SetCardBlock(GameObject droneCard, bool isBlocked)
    {
        SetPurchaseButtonEnabled(droneCard, !isBlocked);
        SetLockIconVisibility(droneCard, isBlocked);
    }

    public void SetLockIconVisibility(GameObject droneCard, bool isVisible)
    {
        Transform lockIconTransform = droneCard.transform.Find("Icon_Lock");

        if (lockIconTransform != null)
        {
            lockIconTransform.gameObject.SetActive(isVisible);
        }
    }

    public void SetPurchaseButtonEnabled(GameObject droneCard, bool isEnabled)
    {
        if (droneCard.TryGetComponent<Button>(out var droneCardButton))
        {
            droneCardButton.enabled = isEnabled;
        }
    }
}
