using UnityEngine;

public class MainMenuDroneMovement : MonoBehaviour
{
    public float upDownSpeed = 2f;
    public float amplitude = 0.5f;

    private Vector3 initialPosition;
    private float timeElapsed = 0f;

    private void Start()
    {
        DroneManager droneManager = DroneManager.instance;
        droneManager.ChangeDronePrefab(gameObject, droneManager.drone);

        initialPosition = transform.position;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        float yOffset = Mathf.Sin(timeElapsed * upDownSpeed) * amplitude;

        Vector3 newPosition = initialPosition + Vector3.up * yOffset;
        transform.position = newPosition;
    }
}
