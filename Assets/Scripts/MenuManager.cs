using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private TextMeshProUGUI goldAmountText;
    private TextMeshProUGUI healthAmountText;

    private void Start()
    {
        GameManager.OnCoinsAmountChanged += CoinsAmountChanged;
        GameManager.OnHealthAmountChanged += HealthAmountChanged;

        GameObject textObject = GameObject.Find("Health_Amount_Text");
        healthAmountText = textObject.GetComponent<TextMeshProUGUI>();

        textObject = GameObject.Find("Gold_Amount_Text");
        goldAmountText = textObject.GetComponent<TextMeshProUGUI>();

        goldAmountText.text = GameManager.instance.CoinsAmount.ToString();
        healthAmountText.text = GameManager.instance.HealthAmount.ToString();
    }

    private void CoinsAmountChanged(int newCoinsAmount)
    {
        goldAmountText.text = newCoinsAmount.ToString();
    }

    private void HealthAmountChanged(int newHealthAmount)
    {
        healthAmountText.text = newHealthAmount.ToString();
    }

    private void OnDestroy()
    {
        GameManager.OnCoinsAmountChanged -= CoinsAmountChanged;
        GameManager.OnHealthAmountChanged -= HealthAmountChanged;
    }
}
