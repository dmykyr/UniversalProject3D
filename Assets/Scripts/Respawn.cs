using UnityEngine;
using UnityEngine.SceneManagement;


public class Respawn : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
     {  
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     }
}
