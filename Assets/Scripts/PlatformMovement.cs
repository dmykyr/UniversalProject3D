using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform targetUp;
    public Transform targetDown;
    public float moveSpeed = 2.0f;

    private bool movingUp = true;

    void Update()
    {
        var targetPosition = movingUp ? targetUp.position : targetDown.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingUp = !movingUp;
        }
    }
}

