using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private int _goldAmount = 0;
    public float moveSpeed = 5f;
    public int GoldAmount { get => _goldAmount; set => _goldAmount = value; }

    void Update()
    {
   
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
 
        Vector3 movement = moveSpeed * Time.deltaTime * new Vector3(horizontalInput, 0f, verticalInput);
 
        transform.Translate(movement);
    }
}
