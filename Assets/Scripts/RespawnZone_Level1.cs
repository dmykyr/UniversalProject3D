using UnityEngine;
using UnityEngine.SceneManagement;


public class RespawnZone_Level1 : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
     {  
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     }
}
