using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public float distanceOffset = 0.3f;
    public float leftOffset = -1f;
    public float heightOffset = 2f;

    private void Start()
    {
        DroneManager droneManager = DroneManager.instance;
        droneManager.ChangeDronePrefab(gameObject, droneManager.drone);
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position - target.forward * distanceOffset + target.right * leftOffset;
            desiredPosition.y = target.position.y + heightOffset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }
}