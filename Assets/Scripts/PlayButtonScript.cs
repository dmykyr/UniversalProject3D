using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void HandleBtnClick()
    {
        SceneManager.LoadScene(1);
    }
}
