using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour 
{
    private UIManager UIManager;
    private Transform OptionsPanel;

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        OptionsPanel = transform.FindChild("Background").FindChild("Options Panel");
    }

    public void OnResumeClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UIManager.HidePauseMenu();
    }

    public void OnOptionsClick()
    {
        OptionsPanel.gameObject.SetActive(true);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
