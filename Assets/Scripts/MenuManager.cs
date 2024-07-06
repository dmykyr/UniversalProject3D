using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject deathScreen;

    private TextMeshProUGUI goldAmountText;
    private TextMeshProUGUI healthAmountText;

    private void Start()
    {
        GameManager.OnCoinsAmountChanged += CoinsAmountChanged;
        GameManager.OnHealthAmountChanged += HealthAmountChanged;
        GameManager.OnCharacterDead += CharacterHasDead;

        GameObject textObject = GameObject.Find("Health_Amount_Text");
        healthAmountText = textObject.GetComponent<TextMeshProUGUI>();

        textObject = GameObject.Find("Gold_Amount_Text");
        goldAmountText = textObject.GetComponent<TextMeshProUGUI>();

        GameManager gameManager = GameManager.instance;
        if(gameManager != null)
        {
            goldAmountText.text = gameManager.CoinsAmount.ToString();
            healthAmountText.text = gameManager.HealthAmount.ToString();
        }
    }

    private void CoinsAmountChanged(int newCoinsAmount)
    {
        goldAmountText.text = newCoinsAmount.ToString();
    }

    private void HealthAmountChanged(int newHealthAmount)
    {
        healthAmountText.text = newHealthAmount.ToString();
    }

    private void CharacterHasDead()
    {
        Time.timeScale = 0;

        deathScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnCoinsAmountChanged -= CoinsAmountChanged;
        GameManager.OnHealthAmountChanged -= HealthAmountChanged;
    }
}
