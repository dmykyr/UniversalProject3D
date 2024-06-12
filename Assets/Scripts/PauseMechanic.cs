using UnityEngine;

public class PauseBtnScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public void HandleBtnClick()
    {
        Time.timeScale = 0;

        PauseMenu.SetActive(true);
    }
}
