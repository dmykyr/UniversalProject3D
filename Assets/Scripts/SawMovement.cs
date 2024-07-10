using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float rotationSpeed = 750f;
    public float moveSpeed = 4f;

    public Transform targetLeft;
    public Transform targetRight;

    private bool movingLeft = true;

    private void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);



        var targetPosition = movingLeft ? targetLeft.position : targetRight.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingLeft = !movingLeft;
        }
    }
}
