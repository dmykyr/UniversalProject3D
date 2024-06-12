using UnityEngine;

public class BtnResumeScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public void HandleBtnClick()
    {
        Time.timeScale = 1;

        PauseMenu.SetActive(false);
    }
}
