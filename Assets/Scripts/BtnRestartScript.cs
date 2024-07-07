using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnRestartScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public void HandleBtnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
