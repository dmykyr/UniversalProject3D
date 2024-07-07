using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject DeathMenu;
    public Button PauseButton;

    private TextMeshProUGUI goldAmountText;
    private TextMeshProUGUI healthAmountText;

    public void Start()
    {
        GameManager.OnCoinsAmountChanged += CoinsAmountChanged;
        GameManager.OnHealthAmountChanged += HealthAmountChanged;
        GameManager.OnCharacterDead += CharacterHasDead;

        InitializeUIElements();

        GameManager gameManager = GameManager.instance;
        if(gameManager != null)
        {
            gameManager.RestoreCurrentResourceValues();
            goldAmountText.text = gameManager.CoinsAmount.ToString();
            healthAmountText.text = gameManager.HealthAmount.ToString();
        }
    }

    public void InitializeUIElements()
    {
        GameObject textObject = GameObject.Find("Health_Amount_Text");
        healthAmountText = textObject.GetComponent<TextMeshProUGUI>();

        textObject = GameObject.Find("Gold_Amount_Text");
        goldAmountText = textObject.GetComponent<TextMeshProUGUI>();

        PauseButton.enabled = true;
    }

    private void CoinsAmountChanged(int newCoinsAmount)
    {
        goldAmountText.text = newCoinsAmount.ToString();
    }

    private void HealthAmountChanged(int newHealthAmount)
    {
        healthAmountText.text = newHealthAmount.ToString();
    }

    public void CharacterHasDead()
    {
        Time.timeScale = 0;

        PauseButton.enabled = false;
        DeathMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnCoinsAmountChanged -= CoinsAmountChanged;
        GameManager.OnHealthAmountChanged -= HealthAmountChanged;
        GameManager.OnCharacterDead -= CharacterHasDead;
    }
}
