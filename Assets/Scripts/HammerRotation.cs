using UnityEngine;

public class HammerRotation : MonoBehaviour
{
    public float startAngle = 80f;
    public float endAngle = -80f;
    public float rotationSpeed = 0.5f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * rotationSpeed, 1f);
        float rotation = Mathf.Lerp(startAngle, endAngle, t);
        transform.rotation = Quaternion.Euler(00, 90, rotation);
    }
}
