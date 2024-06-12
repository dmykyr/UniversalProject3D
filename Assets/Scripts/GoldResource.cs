using UnityEngine;
using TMPro;


public class GoldResource : MonoBehaviour
{
    public float speed_Rotation = 100f;
    private TextMeshProUGUI goldAmountText;
    private Player_Controller player;

    public void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player_Controller>();
        }

        GameObject textObject = GameObject.Find("Gold_Amount_Text");
        goldAmountText = textObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Підібрали монету!");
            player.GoldAmount++;
            goldAmountText.text = player.GoldAmount.ToString();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, speed_Rotation * Time.deltaTime, 0);
    }
}
