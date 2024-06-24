using UnityEngine;
using TMPro;


public class GoldResource : MonoBehaviour
{
    public float speed_Rotation = 100f;
    private TextMeshProUGUI goldAmountText;
    private CharacterMovement character;

    public void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            character = playerObject.GetComponent<CharacterMovement>();
        }

        GameObject textObject = GameObject.Find("Gold_Amount_Text");
        goldAmountText = textObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character.GoldAmount++;
            goldAmountText.text = character.GoldAmount.ToString();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, speed_Rotation * Time.deltaTime, 0);
    }
}
