using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void HandleBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
