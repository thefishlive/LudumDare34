using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour 
{
    private UIManager UIManager;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
    }

    public void OnResumeClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UIManager.HidePauseMenu();
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
