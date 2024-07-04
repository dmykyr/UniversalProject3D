using UnityEngine;

public class HealthResource : MonoBehaviour
{
    public float speed_Rotation = 100f;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.HealthAmount++;
            }

            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, speed_Rotation * Time.deltaTime, 0);
    }
}
